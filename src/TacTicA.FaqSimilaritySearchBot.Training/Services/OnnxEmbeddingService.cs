using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Text.Json;
using System.Text.RegularExpressions;
using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using Microsoft.Extensions.Options;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;

public class OnnxEmbeddingService : IEmbeddingService, IDisposable
{
    private readonly InferenceSession _session;
    private readonly Dictionary<string, int> _vocabulary;
    private readonly int _maxLength;
    private readonly int _embeddingDimension;
    private bool _disposed = false;

    public OnnxEmbeddingService(IOptions<EmbeddingSettings> embeddingSettings)
    {
        _embeddingDimension = embeddingSettings.Value.EmbeddingDimension;
        _maxLength = embeddingSettings.Value.MaxSequenceLength;
        
        // Use default model path if not provided
        var currentDirectory = Directory.GetCurrentDirectory();
        string modelPath = Path.IsPathRooted(embeddingSettings.Value.ModelPath)
           ? embeddingSettings.Value.ModelPath
           : Path.Combine(currentDirectory, embeddingSettings.Value.ModelPath);

        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException($"ONNX model file not found at: {modelPath}");
        }

        try
        {
            _session = new InferenceSession(modelPath);
            _vocabulary = LoadVocabulary(Path.ChangeExtension(modelPath, null));
            Console.WriteLine($"✅ ONNX model loaded successfully from: {modelPath}");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Failed to load ONNX model from {modelPath}: {ex.Message}", ex);
        }
    }

    public async Task<float[]> GetEmbeddingAsync(string text)
    {
        return await Task.Run(() => GetEmbedding(text));
    }

    public async Task<float[][]> GetEmbeddingsAsync(IEnumerable<string> texts)
    {
        return await Task.Run(() => texts.Select(GetEmbedding).ToArray());
    }

    private float[] GetEmbedding(string text)
    {
        try
        {
            // Normalize text
            text = text.ToLowerInvariant().Trim();
            
            // Tokenize the text
            var tokens = TokenizeText(text);
            var inputIds = TokensToIds(tokens);
            
            // Pad or truncate to max length
            Array.Resize(ref inputIds, _maxLength);
            
            // Create attention mask (1 for real tokens, 0 for padding)
            var attentionMask = inputIds.Select(id => id != 0 ? 1 : 0).ToArray();
            
            // Create token type ids (all 0s for single sentence)
            var tokenTypeIds = new int[_maxLength]; // All zeros for single sentence

            // Create input tensors
            var inputIdsTensor = new DenseTensor<long>(
                inputIds.Select(id => (long)id).ToArray(), 
                new[] { 1, _maxLength }
            );
            var attentionMaskTensor = new DenseTensor<long>(
                attentionMask.Select(mask => (long)mask).ToArray(), 
                new[] { 1, _maxLength }
            );
            var tokenTypeIdsTensor = new DenseTensor<long>(
                tokenTypeIds.Select(id => (long)id).ToArray(), 
                new[] { 1, _maxLength }
            );

            var inputs = new List<NamedOnnxValue>
            {
                // The tokenized text
                NamedOnnxValue.CreateFromTensor("input_ids", inputIdsTensor),
                // Real tokens vs padding
                NamedOnnxValue.CreateFromTensor("attention_mask", attentionMaskTensor),
                /*
                In BERT, token_type_ids distinguishes between different segments of text:
                    0: First sentence (or single sentence)
                    1: Second sentence (for sentence pair tasks)
                For single sentences (like we're doing): All values should be 0.

                For sentence pairs (like question-answering):

                Since we're only processing single sentences for embedding generation, we set all token_type_ids to 0.
                */
                NamedOnnxValue.CreateFromTensor("token_type_ids", tokenTypeIdsTensor)
            };

            // Run inference
            using var results = _session.Run(inputs);
            var embeddings = results.First().AsTensor<float>();
            
            // Extract sentence embedding (usually mean pooling of token embeddings)
            var embedding = MeanPooling(embeddings, attentionMask);
            
            // Normalize the embedding
            return NormalizeEmbedding(embedding);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating embedding: {ex.Message}");
            // Fallback to simple embedding if ONNX fails
            return GenerateFallbackEmbedding(text);
        }
    }

    private int[] TokensToIds(string[] tokens)
    {
        var ids = new List<int> { _vocabulary.GetValueOrDefault("[CLS]", 2) }; // Start with CLS token
        
        foreach (var token in tokens)
        {
            ids.Add(_vocabulary.GetValueOrDefault(token, _vocabulary.GetValueOrDefault("[UNK]", 1)));
        }
        
        ids.Add(_vocabulary.GetValueOrDefault("[SEP]", 3)); // End with SEP token
        return ids.ToArray();
    }

    private float[] MeanPooling(Tensor<float> embeddings, int[] attentionMask)
    {
        var embeddingSize = embeddings.Dimensions[2];
        var seqLength = embeddings.Dimensions[1];
        var pooled = new float[embeddingSize];
        var validTokens = 0;

        for (int i = 0; i < seqLength; i++)
        {
            if (attentionMask[i] == 1) // Only pool non-padding tokens
            {
                for (int j = 0; j < embeddingSize; j++)
                {
                    pooled[j] += embeddings[0, i, j];
                }
                validTokens++;
            }
        }

        // Average the pooled embeddings
        if (validTokens > 0)
        {
            for (int i = 0; i < embeddingSize; i++)
            {
                pooled[i] /= validTokens;
            }
        }

        return pooled;
    }

    private float[] NormalizeEmbedding(float[] embedding)
    {
        var magnitude = (float)Math.Sqrt(embedding.Sum(x => x * x));
        if (magnitude > 0)
        {
            for (int i = 0; i < embedding.Length; i++)
            {
                embedding[i] /= magnitude;
            }
        }
        return embedding;
    }

    private float[] GenerateFallbackEmbedding(string text)
    {
        // Fallback to simple hash-based embedding if ONNX fails
        var hash = text.GetHashCode();
        var random = new Random(hash);
        var embedding = new float[_embeddingDimension];
        
        for (int i = 0; i < _embeddingDimension; i++)
        {
            embedding[i] = (float)(random.NextDouble() * 2 - 1);
        }
        
        return NormalizeEmbedding(embedding);
    }

    private string[] TokenizeText(string text)
    {
        // Simple word-level tokenization
        // For production, you'd use the model's specific tokenizer
        text = text.ToLowerInvariant();
        text = Regex.Replace(text, @"[^\w\s]", " ");
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private Dictionary<string, int> LoadVocabulary(string baseModelPath)
    {
        var vocabPath = baseModelPath + "_vocab.txt";
        var tokenizerPath = baseModelPath + "_tokenizer.json";

        // Try to load from vocab.txt first
        if (File.Exists(vocabPath))
        {
            return LoadVocabFromFile(vocabPath);
        }

        // Try to load from tokenizer.json
        if (File.Exists(tokenizerPath))
        {
            return LoadVocabFromTokenizer(tokenizerPath);
        }

        // Fallback to basic vocabulary
        Console.WriteLine("Warning: Using fallback vocabulary. Download proper vocabulary files for better results.");
        return CreateBasicVocabulary();
    }

    private Dictionary<string, int> LoadVocabFromFile(string vocabPath)
    {
        var vocab = new Dictionary<string, int>();
        var lines = File.ReadAllLines(vocabPath);
        
        for (int i = 0; i < lines.Length; i++)
        {
            vocab[lines[i].Trim()] = i;
        }
        
        return vocab;
    }

    private Dictionary<string, int> LoadVocabFromTokenizer(string tokenizerPath)
    {
        try
        {
            var json = File.ReadAllText(tokenizerPath);
            var tokenizer = JsonDocument.Parse(json);
            
            var vocab = new Dictionary<string, int>();
            var vocabSection = tokenizer.RootElement.GetProperty("model").GetProperty("vocab");
            
            foreach (var kvp in vocabSection.EnumerateObject())
            {
                vocab[kvp.Name] = kvp.Value.GetInt32();
            }
            
            return vocab;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading tokenizer: {ex.Message}");
            return CreateBasicVocabulary();
        }
    }

    private Dictionary<string, int> CreateBasicVocabulary()
    {
        // Create a basic vocabulary with common localization terms
        var vocab = new Dictionary<string, int>
        {
            ["[PAD]"] = 0,
            ["[UNK]"] = 1,
            ["[CLS]"] = 2,
            ["[SEP]"] = 3,
            // Add common localization terms
            ["localization"] = 100,
            ["translation"] = 101,
            ["edge"] = 102,
            ["fix"] = 103,
            ["correct"] = 104,
            ["bad"] = 105,
            ["string"] = 106,
            ["grd"] = 107,
            ["pak"] = 108,
            ["pseudo"] = 109,
            ["test"] = 110,
            ["guide"] = 111,
            ["process"] = 112,
            ["review"] = 113,
            ["workflow"] = 114,
            ["build"] = 115
        };

        // Add more common English words
        var commonWords = new[] { "the", "a", "an", "and", "or", "but", "in", "on", "at", "to", "for", "of", "with", "by", "how", "what", "when", "where", "why", "is", "are", "was", "were", "do", "does", "did", "will", "would", "could", "should", "can", "may", "might" };
        
        for (int i = 0; i < commonWords.Length; i++)
        {
            vocab[commonWords[i]] = 200 + i;
        }

        return vocab;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _session?.Dispose();
            _disposed = true;
        }
    }
}