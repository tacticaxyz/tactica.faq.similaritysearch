using TacTicA.FaqSimilaritySearchBot.Shared.Models;
using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;

public class DataProcessingService : IDataProcessingService
{
    private readonly IEmbeddingService _embeddingService;
    private readonly ILogger<DataProcessingService> _logger;
    private readonly HttpClient _httpClient;
    private readonly DataPaths _dataPaths;
    private readonly ProcessingSettings _processingSettings;
    private const int MaxTokensPerChunk = 500;

    public DataProcessingService(
        IEmbeddingService embeddingService, 
        ILogger<DataProcessingService> logger,
        IOptions<DataPaths> dataPaths,
        IOptions<ProcessingSettings> processingSettings)
    {
        _embeddingService = embeddingService;
        _logger = logger;
        _dataPaths = dataPaths.Value;
        _processingSettings = processingSettings.Value;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "TacTicA.FaqSimilaritySearchBot/1.0");
    }

    public async Task<List<QuestionAnswerPair>> LoadQuestionsAndAnswersAsync(string filePath)
    {
        _logger.LogInformation("Loading Q&A data from {FilePath}", filePath);
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Q&A file not found: {filePath}");
        }

        var lines = await File.ReadAllLinesAsync(filePath);
        var qaData = new List<QuestionAnswerPair>();

        // First pass: collect all questions and answers for TF-IDF initialization
        var allTexts = new List<string>();
        var tempQaPairs = new List<(string question, string answer)>();

        for (int i = 0; i < lines.Length; i++)
        {
            var currentLine = lines[i].Trim();

            // Skip empty lines
            if (string.IsNullOrEmpty(currentLine))
                continue;

            if (currentLine.StartsWith("Q:"))
            {
                // Current line should be a question
                var question = currentLine.Substring(2);

                // Look for the answer on the next non-empty line
                string? answerLine = lines[i + 1].Trim();
                
                if (!string.IsNullOrEmpty(answerLine) && answerLine.StartsWith("A:"))
                {
                    answerLine = answerLine.Substring(2);
                    tempQaPairs.Add((question, answerLine));

                    // Add both question and answer to corpus for TF-IDF
                    allTexts.Add(question);
                    allTexts.Add(answerLine);
                }
            }
            else
            {
                continue;
            }
        }

        // Initialize TF-IDF embedding service with all texts if applicable
        if (_embeddingService is TfIdfEmbeddingService tfidfService)
        {
            tfidfService.InitializeWithCorpus(allTexts);
            _logger.LogInformation("Initialized TF-IDF service with {Count} texts", allTexts.Count);
        }

        // Second pass: generate embeddings
        foreach (var (question, answer) in tempQaPairs)
        {

            var qa = new QuestionAnswerPair
            {
                Id = Guid.NewGuid().ToString(),
                Question = question,
                Answer = answer,
                WikiLinks = ExtractLinks(answer),
                Category = InferCategory(question)
            };

            // Generate embedding for the question
            qa.Embedding = await _embeddingService.GetEmbeddingAsync(question);
            qaData.Add(qa);
            _logger.LogInformation("Processed Q&A: {Question}", question.Substring(0, Math.Min(50, question.Length)));
            _logger.LogInformation("Processed Answer: {Answer}", answer.Substring(0, Math.Min(50, answer.Length)));
        }

        _logger.LogInformation("Loaded {Count} Q&A pairs", qaData.Count);
        return qaData;
    }

    public async Task<List<string>> LoadWikiLinksAsync(string filePath)
    {
        _logger.LogInformation("Loading wiki links from {FilePath}", filePath);
        
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Wiki links file not found: {filePath}");
        }

        var lines = await File.ReadAllLinesAsync(filePath);
        var links = lines
            .Where(line => !string.IsNullOrWhiteSpace(line) && Uri.IsWellFormedUriString(line.Trim(), UriKind.Absolute))
            .Select(line => line.Trim())
            .Distinct()
            .ToList();

        _logger.LogInformation("Loaded {Count} wiki links", links.Count);
        return links;
    }

    public async Task<List<DocumentChunk>> ProcessWikiContentAsync(IEnumerable<string> wikiLinks)
    {
        _logger.LogInformation("Processing wiki content from {Count} links", wikiLinks.Count());
        
        var documentChunks = new List<DocumentChunk>();

        // First, try to load exported content
        var exportedChunks = new List<DocumentChunk>();
        exportedChunks = await LoadExportedContentAsync();
        documentChunks.AddRange(exportedChunks);

        // Only try to download URLs if we don't have exported content or want to supplement it
        //foreach (var link in wikiLinks)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Processing wiki page: {Link}", link);

        //        // Skip if we already have exported content for this URL
        //        if (exportedChunks.Any(chunk => chunk.SourceUrl.Equals(link, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            _logger.LogInformation("Skipping {Link} - already have exported content", link);
        //            continue;
        //        }

        //        var content = await DownloadContentAsync(link);

        //        // Check if content looks like an authentication error
        //        if (IsAuthenticationError(content))
        //        {
        //            _logger.LogWarning("Skipping {Link} - authentication required", link);
        //            continue;
        //        }
                
        //        var chunks = ChunkContent(content, link);

        //        foreach (var chunk in chunks)
        //        {
        //            chunk.Embedding = await _embeddingService.GetEmbeddingAsync(chunk.Content);
        //            documentChunks.Add(chunk);
        //        }

        //        _logger.LogInformation("Created {ChunkCount} chunks for {Link}", chunks.Count, link);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogWarning(ex, "Failed to process wiki page: {Link}", link);
        //    }
        //}

        _logger.LogInformation("Created {Count} document chunks", documentChunks.Count);
        return documentChunks;
    }

    private async Task<List<DocumentChunk>> LoadExportedContentAsync()
    {
        var exportedChunks = new List<DocumentChunk>();
        
        // Use configured path for exported content
        var exportedContentPath = Path.GetFullPath(_dataPaths.ExportedContentDirectory);
        
        if (!Directory.Exists(exportedContentPath))
        {
            _logger.LogInformation("Exported content directory not found: {Path}", exportedContentPath);
            return exportedChunks;
        }

        _logger.LogInformation("Found exported content directory at {Path}", exportedContentPath);

        // Look for content files
        var allFiles = Directory.GetFiles(exportedContentPath, "*.md", SearchOption.AllDirectories);
        //var txtFiles = Directory.GetFiles(exportedContentPath, "*.txt", SearchOption.AllDirectories);
        //var allFiles = mdFiles.Concat(txtFiles).ToArray();
        //var contentFiles = allFiles.Where(f => !Path.GetFileName(f).Equals("README.md", StringComparison.OrdinalIgnoreCase)).ToArray();

        _logger.LogInformation($"Found {allFiles.Length} files");
        //_logger.LogInformation($"Total files after filtering: {contentFiles.Length}");
        //_logger.LogInformation("Files to process: {Files}", string.Join(", ", contentFiles.Select(f => Path.GetFileName(f))));

        foreach (var filePath in allFiles)
        {
            try
            {
                _logger.LogInformation("Processing exported file: {File}", filePath);
                var content = await File.ReadAllTextAsync(filePath);
                _logger.LogInformation("Read {Length} characters from {File}", content.Length, Path.GetFileName(filePath));
                
                var parsedContent = ParseExportedContent(content, filePath);
                
                if (parsedContent == null)
                {
                    _logger.LogWarning("Failed to parse content from {File}", Path.GetFileName(filePath));
                    continue;
                }
                
                if (string.IsNullOrWhiteSpace(parsedContent.Content))
                {
                    _logger.LogWarning("Parsed content is empty for {File}", Path.GetFileName(filePath));
                    continue;
                }
                
                _logger.LogInformation("Parsed content from {File}: Title='{Title}', Content length={Length}", 
                    Path.GetFileName(filePath), parsedContent.Title, parsedContent.Content.Length);
                
                var chunks = ChunkContent(parsedContent.Content, parsedContent.Url, parsedContent.Title);
                _logger.LogInformation("Generated {ChunkCount} chunks from {File}", chunks.Count, Path.GetFileName(filePath));
                
                foreach (var chunk in chunks)
                {
                    chunk.Embedding = await _embeddingService.GetEmbeddingAsync(chunk.Content);
                    exportedChunks.Add(chunk);
                }
                
                _logger.LogInformation("Successfully processed {File} - added {ChunkCount} chunks", Path.GetFileName(filePath), chunks.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process exported file: {File}", filePath);
            }
        }

        _logger.LogInformation("Loaded {Count} chunks from exported content", exportedChunks.Count);
        return exportedChunks;
    }

    private ExportedContent? ParseExportedContent(string content, string filePath)
    {
        var lines = content.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        var title = Path.GetFileNameWithoutExtension(filePath).Replace("-", " ").Replace("_", " ");
        var url = "";
        var actualContent = new List<string>();
        var inContent = false;

        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            
            if (trimmed.StartsWith("URL:", StringComparison.OrdinalIgnoreCase))
            {
                url = trimmed.Substring(4).Trim();
            }
            else if (!inContent && (trimmed.StartsWith("#") || actualContent.Count > 0))
            {
                inContent = true;
                actualContent.Add(line);
            }
            else if (inContent)
            {
                actualContent.Add(line);
            }
        }

        _logger.LogInformation("Loaded {Count} lines of content", actualContent.Count);

        return new ExportedContent
        {
            Title = title,
            Url = string.IsNullOrEmpty(url) ? $"file://{filePath}" : url,
            Content = string.Join("\n", actualContent)
        };
    }

    //private bool IsAuthenticationError(string content)
    //{
    //    if (string.IsNullOrWhiteSpace(content))
    //        return true;

    //    var authIndicators = new[]
    //    {
    //        "sign in",
    //        "authentication",
    //        "enhanced security configuration",
    //        "anonymous sign out",
    //        "azure devops services",
    //        "access denied",
    //        "unauthorized",
    //        "login required"
    //    };

    //    var lowerContent = content.ToLowerInvariant();
    //    return authIndicators.Any(indicator => lowerContent.Contains(indicator)) && content.Length < 1000;
    //}

    public async Task SaveProcessedDataAsync(string outputPath, List<QuestionAnswerPair> qaData, List<DocumentChunk> documentChunks)
    {
        _logger.LogInformation("Saving processed data to {OutputPath}", outputPath);
        
        Directory.CreateDirectory(outputPath);

        var qaPath = Path.Combine(outputPath, "qa_embeddings.json");
        var chunksPath = Path.Combine(outputPath, "document_chunks.json");
        var configPath = Path.Combine(outputPath, "config.json");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        await File.WriteAllTextAsync(qaPath, JsonSerializer.Serialize(qaData, options));
        await File.WriteAllTextAsync(chunksPath, JsonSerializer.Serialize(documentChunks, options));

        var config = new
        {
            CreatedAt = DateTime.UtcNow,
            QACount = qaData.Count,
            DocumentChunkCount = documentChunks.Count,
            EmbeddingDimension = qaData.FirstOrDefault()?.Embedding?.Length ?? 0,
            DefaultSimilarityThreshold = _processingSettings.SimilarityThreshold
        };

        await File.WriteAllTextAsync(configPath, JsonSerializer.Serialize(config, options));

        _logger.LogInformation("Saved processed data: {QACount} Q&A pairs, {ChunkCount} document chunks", 
            qaData.Count, documentChunks.Count);
    }

    private async Task<string> DownloadContentAsync(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            
            var html = await response.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            
            // Extract text content, removing script and style elements
            var textNodes = doc.DocumentNode.SelectNodes("//text()[not(parent::script) and not(parent::style)]");
            if (textNodes == null) return string.Empty;
            
            var content = string.Join(" ", textNodes.Select(node => node.InnerText.Trim()))
                .Replace("\n", " ")
                .Replace("\t", " ");
            
            // Clean up multiple spaces
            content = Regex.Replace(content, @"\s+", " ").Trim();
            
            return content;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to download content from {Url}", url);
            return string.Empty;
        }
    }

    private List<DocumentChunk> ChunkContent(string content, string sourceUrl, string? providedTitle = null)
    {
        if (string.IsNullOrWhiteSpace(content))
            return new List<DocumentChunk>();

        var chunks = new List<DocumentChunk>();
        var sentences = SplitIntoSentences(content);
        var currentChunk = new List<string>();
        var currentTokenCount = 0;
        var title = providedTitle ?? ExtractTitle(sourceUrl);

        foreach (var sentence in sentences)
        {
            var sentenceTokenCount = EstimateTokenCount(sentence);

            if (currentTokenCount + sentenceTokenCount > MaxTokensPerChunk && currentChunk.Count > 0)
            {
                // Create chunk from current sentences
                var chunkContent = string.Join(" ", currentChunk);
                chunks.Add(new DocumentChunk
                {
                    Id = Guid.NewGuid().ToString(),
                    Content = chunkContent,
                    SourceUrl = sourceUrl,
                    Title = title,
                    Section = $"Section {chunks.Count + 1}",
                    TokenCount = currentTokenCount
                });
                currentChunk.Clear();
                currentTokenCount = 0;
            }

            currentChunk.Add(sentence);
            currentTokenCount += sentenceTokenCount;
        }

        // Add final chunk
        if (currentChunk.Count > 0)
        {
            var chunkContent = string.Join(" ", currentChunk);
            chunks.Add(new DocumentChunk
            {
                Id = Guid.NewGuid().ToString(),
                Content = chunkContent,
                SourceUrl = sourceUrl,
                Title = title,
                Section = $"Section {chunks.Count + 1}",
                TokenCount = currentTokenCount
            });
        }

        return chunks;
    }

    private List<string> SplitIntoSentences(string content)
    {
        // Simple sentence splitting - can be improved with proper NLP library
        var sentences = Regex.Split(content, @"[.!?]+\s+")
            .Where(s => !string.IsNullOrWhiteSpace(s) && s.Length > 10)
            .ToList();

        return sentences;
    }

    private int EstimateTokenCount(string text)
    {
        // Rough estimation: 1 token ≈ 4 characters
        return text.Length / 4;
    }

    private string ExtractTitle(string url)
    {
        var uri = new Uri(url);
        var lastSegment = uri.Segments.LastOrDefault()?.TrimEnd('/');
        return lastSegment?.Replace("-", " ").Replace("_", " ") ?? "Unknown";
    }

    private List<string> ExtractLinks(string answerText)
    {
        var urlPattern = @"https?://[^\s<>""{}|\\^`\[\]]+";
        var matches = Regex.Matches(answerText, urlPattern);
        return matches.Select(m => m.Value).ToList();
    }

    private string InferCategory(string question)
    {
        var lowerQuestion = question.ToLowerInvariant();
        
        if (lowerQuestion.Contains("string") || lowerQuestion.Contains("text") || lowerQuestion.Contains("localization"))
            return "Localization";
        if (lowerQuestion.Contains("translation") || lowerQuestion.Contains("translate"))
            return "Translation";
        if (lowerQuestion.Contains("format") || lowerQuestion.Contains("formatting"))
            return "Formatting";
        if (lowerQuestion.Contains("culture") || lowerQuestion.Contains("locale"))
            return "Culture";
        
        return "General";
    }
}
