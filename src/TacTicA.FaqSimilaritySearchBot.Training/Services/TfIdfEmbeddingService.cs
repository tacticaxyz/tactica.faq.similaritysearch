using System.Text.RegularExpressions;
using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using Microsoft.Extensions.Options;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;

/// <summary>
/// TF-IDF based embedding service that provides more realistic semantic understanding
/// while remaining self-contained without external dependencies
/// </summary>
public class TfIdfEmbeddingService : IEmbeddingService
{
    private readonly int _embeddingDimension;
    private readonly Dictionary<string, int> _vocabulary = new();
    private readonly Dictionary<string, double> _inverseDocumentFrequency = new();
    private readonly List<string> _corpus = new();
    private readonly object _lockObject = new();
    private bool _isInitialized = false;

    public TfIdfEmbeddingService(IOptions<EmbeddingSettings> embeddingSettings)
    {
        _embeddingDimension = embeddingSettings.Value.EmbeddingDimension;
    }

    public async Task<float[]> GetEmbeddingAsync(string text)
    {
        // Auto-initialize with the text if not already done
        if (!_isInitialized)
        {
            lock (_lockObject)
            {
                if (!_isInitialized)
                {
                    InitializeWithSingleDocument(text);
                }
            }
        }

        return await Task.FromResult(CreateTfIdfEmbedding(text));
    }

    public async Task<float[][]> GetEmbeddingsAsync(IEnumerable<string> texts)
    {
        var textList = texts.ToList();
        
        // Initialize vocabulary with all texts first
        if (!_isInitialized)
        {
            lock (_lockObject)
            {
                if (!_isInitialized)
                {
                    InitializeCorpus(textList);
                }
            }
        }

        var tasks = textList.Select(text => Task.FromResult(CreateTfIdfEmbedding(text)));
        return await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Initialize the service with a corpus of documents for better IDF calculation
    /// </summary>
    public void InitializeWithCorpus(IEnumerable<string> documents)
    {
        lock (_lockObject)
        {
            InitializeCorpus(documents.ToList());
        }
    }

    private void InitializeCorpus(List<string> documents)
    {
        _corpus.Clear();
        _vocabulary.Clear();
        _inverseDocumentFrequency.Clear();

        // Add documents to corpus
        _corpus.AddRange(documents);

        // Build vocabulary from all documents
        var vocabularySet = new HashSet<string>();
        foreach (var doc in documents)
        {
            var words = TokenizeText(doc);
            foreach (var word in words)
            {
                vocabularySet.Add(word);
            }
        }

        // Assign indices to vocabulary words
        var vocabList = vocabularySet.OrderBy(w => w).ToList();
        for (int i = 0; i < vocabList.Count; i++)
        {
            _vocabulary[vocabList[i]] = i;
        }

        // Calculate IDF for each term
        CalculateInverseDocumentFrequency();
        
        _isInitialized = true;
    }

    private void InitializeWithSingleDocument(string document)
    {
        // For single document, create a simple vocabulary
        var words = TokenizeText(document);
        var uniqueWords = words.Distinct().OrderBy(w => w).ToList();
        
        for (int i = 0; i < uniqueWords.Count; i++)
        {
            _vocabulary[uniqueWords[i]] = i;
            // For single document, IDF is just 1 (log(1/1) = 0, so we use 1)
            _inverseDocumentFrequency[uniqueWords[i]] = 1.0;
        }
        
        _corpus.Add(document);
        _isInitialized = true;
    }

    private void CalculateInverseDocumentFrequency()
    {
        var totalDocuments = _corpus.Count;
        
        foreach (var term in _vocabulary.Keys)
        {
            // Count how many documents contain this term
            var documentsContainingTerm = _corpus.Count(doc => 
                TokenizeText(doc).Contains(term, StringComparer.OrdinalIgnoreCase));
            
            // Calculate IDF: log(total_documents / documents_containing_term)
            // Add 1 to avoid division by zero
            var idf = Math.Log((double)totalDocuments / (documentsContainingTerm + 1)) + 1;
            _inverseDocumentFrequency[term] = idf;
        }
    }

    private float[] CreateTfIdfEmbedding(string text)
    {
        // Tokenize the input text
        var words = TokenizeText(text);
        var wordCount = words.Count;
        
        // Calculate term frequencies
        var termFrequencies = new Dictionary<string, double>();
        foreach (var word in words)
        {
            termFrequencies[word] = termFrequencies.GetValueOrDefault(word, 0) + 1.0;
        }

        // Normalize TF by document length
        foreach (var key in termFrequencies.Keys.ToList())
        {
            termFrequencies[key] = termFrequencies[key] / wordCount;
        }

        // Create sparse TF-IDF vector
        var tfidfVector = new Dictionary<int, double>();
        foreach (var (term, tf) in termFrequencies)
        {
            if (_vocabulary.TryGetValue(term, out var index) && 
                _inverseDocumentFrequency.TryGetValue(term, out var idf))
            {
                var tfidf = tf * idf;
                if (tfidf > 0)
                {
                    tfidfVector[index] = tfidf;
                }
            }
        }

        // Convert to dense embedding vector
        return ConvertToDenseEmbedding(tfidfVector, text);
    }

    private float[] ConvertToDenseEmbedding(Dictionary<int, double> sparseVector, string originalText)
    {
        var embedding = new float[_embeddingDimension];
        
        // Method 1: Hash-based mapping with TF-IDF weighting
        var textHash = originalText.GetHashCode();
        var random = new Random(Math.Abs(textHash));
        
        // Initialize with small random values
        for (int i = 0; i < _embeddingDimension; i++)
        {
            embedding[i] = (float)(random.NextDouble() * 0.1 - 0.05); // Small random baseline
        }
        
        // Add TF-IDF weighted components
        foreach (var (vocabIndex, tfidfValue) in sparseVector)
        {
            // Map vocabulary index to multiple embedding dimensions
            var wordHash = vocabIndex.GetHashCode();
            var wordRandom = new Random(Math.Abs(wordHash));
            
            // Influence multiple dimensions based on TF-IDF weight
            var influenceCount = Math.Max(1, (int)(tfidfValue * 5)); // More important words influence more dimensions
            
            for (int i = 0; i < influenceCount && i < _embeddingDimension / 10; i++)
            {
                var dimIndex = Math.Abs(wordRandom.Next()) % _embeddingDimension;
                var influence = (float)(tfidfValue * (wordRandom.NextDouble() * 2 - 1));
                embedding[dimIndex] += influence;
            }
        }
        
        // Add keyword-based semantic boosting
        AddSemanticBoosting(embedding, originalText);
        
        // Normalize the vector to unit length
        NormalizeVector(embedding);
        
        return embedding;
    }

    private void AddSemanticBoosting(float[] embedding, string text)
    {
        var lowerText = text.ToLower();
        
        // Calculate cluster size based on embedding dimension
        var clusterSize = Math.Max(10, _embeddingDimension / 8); // Dynamic cluster sizing
        
        // Define semantic clusters with their associated dimensions
        var semanticClusters = new Dictionary<string[], int[]>
        {
            // Chromium browsers terms cluster
            {
                new[] { "chromium", "chrome", "browser", "google", "c++", "ninja", "code", "script", "html" },
                Enumerable.Range(0, clusterSize).ToArray()
            },
            // Technical terms cluster  
            {
                new[] { "cmake", "gn", "unittest", "unit", "test", "gtest", "gclient", "include", "toolchain", "pnacl", "nativ", "platf",
                "sandbox", "commit", "pullreq", "clang", "cl", "client", "release", "debug", "device", "css", "function", "memory", "access", "struct", "schema",
                "source", "static", "unsafe", "bindgen", "cxx", "extern", "bridge", "librar", "tutorial", "thread", "buffer", "generat",
                "grd", "grdp", "pak", "resource", "icu", "pipeline", "web", "webui" },
                Enumerable.Range(clusterSize, clusterSize).ToArray()
            },
            // Process terms cluster
            {
                new[] { "test", "deploy", "build", "rust", "v8", "javascript", "wasm", "webassembly" },
                Enumerable.Range(clusterSize * 2, clusterSize).ToArray()
            },
            // Action terms cluster
            {
                new[] { "how", "what", "where", "when", "why", "which", "can", "do", "does",
                "help", "guid", "process", "work", "fix", "problem", "manage",
                "add", "creat", "updat", "chang", "handl", "manag", "configur" },
                Enumerable.Range(clusterSize * 3, clusterSize).ToArray()
            }
        };
        
        // Boost dimensions based on semantic clusters
        foreach (var (keywords, dimensions) in semanticClusters)
        {
            var matchCount = keywords.Count(keyword => lowerText.Contains(keyword));
            if (matchCount > 0)
            {
                var boost = (float)(matchCount * 0.3); // Boost factor
                foreach (var dim in dimensions)
                {
                    if (dim < _embeddingDimension)
                    {
                        embedding[dim] += boost;
                    }
                }
            }
        }
    }

    private void NormalizeVector(float[] vector)
    {
        // Calculate L2 norm (Euclidean magnitude)
        var magnitude = (float)Math.Sqrt(vector.Sum(x => x * x));
        
        // Avoid division by zero
        if (magnitude > 0)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] /= magnitude;
            }
        }
    }

    private List<string> TokenizeText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return new List<string>();

        // Convert to lowercase and remove special characters
        var cleanText = Regex.Replace(text.ToLower(), @"[^\w\s]", " ");
        
        // Split into words and remove empty/short words
        var words = cleanText
            .Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)
            .Where(word => word.Length > 2) // Only keep words longer than 2 characters
            .Where(word => !IsStopWord(word)) // Remove common stop words
            .ToList();
            
        return words;
    }

    private bool IsStopWord(string word)
    {
        // Common English stop words that don't contribute much to meaning
        var stopWords = new HashSet<string>
        {
            "the", "and", "for", "are", "but", "not", "you", "all", "can", "had", "her", "was", "one", "our", "out", "day", "get", "has", "him",
            "his", "how", "its", "may", "new", "now", "old", "see", "two", "way", "who", "boy", "did", "has", "let", "put", "say", "she", "too", "use"
        };
        
        return stopWords.Contains(word);
    }

    public void Dispose()
    {
        _vocabulary.Clear();
        _inverseDocumentFrequency.Clear();
        _corpus.Clear();
    }
}
