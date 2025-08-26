using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using Microsoft.Extensions.Options;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;

// Simplified embedding service for demonstration
public class SimpleEmbeddingService : IEmbeddingService
{
    private readonly Random _random = new(42); // Fixed seed for consistency
    private readonly int _embeddingDimension;

    public SimpleEmbeddingService(IOptions<EmbeddingSettings> embeddingSettings)
    {
        _embeddingDimension = embeddingSettings.Value.EmbeddingDimension;
    }

    // The embedding dimension is simply the length of embedding vectors. 
    // Popular sentence transformer models using 384 dimensions:
    // - all-MiniLM-L6-v2 (384 dimensions)
    // - paraphrase-MiniLM-L6-v2 (384 dimensions)
    // - all-MiniLM-L12-v2 (384 dimensions)
    // Popular Model Architectures:
    // - BERT-base derivatives: Many sentence transformer models are based on 
    // BERT-base (768 dimensions) but use half the dimension (384) for efficiency
    // - DistilBERT: Uses 768 dimensions, but many sentence transformers compress this to 384
    // - MiniLM models: Microsoft's MiniLM-L6/L12 models commonly use 384 dimensions
    //
    // So, values used are:
    // - 768: BERT-base, RoBERTa-base
    // - 512: Some custom models, T5 variants
    // - 256: Very lightweight models
    // - 1024: BERT-large, larger models
    // - 1536: OpenAI's text-embedding-ada-002
    //
    // Mathematical Benefits
    //- Divisible by common factors: 384 = 2⁷ × 3, making it efficient for various mathematical operations
    // - GPU-friendly: Works well with common GPU memory alignments
    // - Batch processing: Efficient for matrix operations in neural networks
    //
    // Higher dimensions can capture more subtle relationships but may lead to 
    // overfitting or increased computation. Lower dimensions are faster and simpler but might miss important nuances.
    // Empirical Research studies have shown that beyond 384-512 dimensions, 
    // performance gains are minimal for most sentence similarity tasks.
    // Very high dimensions can actually hurt performance in some cases.
    // Note: EmbeddingDimension is now configurable via appsettings.json

    public Task<float[]> GetEmbeddingAsync(string text)
    {
        // Normalize text for consistent embedding generation
        var normalizedText = NormalizeText(text);
        
        // Generate deterministic embeddings based on text hash,
        // because we don't have external dependencies or model files.
        // Benefits:
        // - No dependencies on model
        // - Same text always produces the same embedding
        // - Consistent results across runs
        // 
        // Problems:
        // - No semantic understanding
        // - "cat" and "dog" get completely unrelated embeddings
        // - Hash collisions can cause different texts to have similar embeddings
        // 
        // Why hash?
        // Direct text encoding (without hash) creates huge, mostly-zero vectors that are inefficient.
        // Plus, character-based approaches can't tell two sentences are similar.
        var hash = GetHashCode(normalizedText); // Not using text.GetHashCode() from .NET

        //var random = new Random(hash); // Not using from .NET
        var nextRandomDouble = SeededRandom(hash);

        var embedding = new float[_embeddingDimension];
        for (int i = 0; i < _embeddingDimension; i++)
        {
            //embedding[i] = (float)(random.NextDouble() * 2 - 1); // Not using from .NET
            embedding[i] = (float)(nextRandomDouble() * 2.0 - 1.0); // Range [-1, 1] 
        }

        // Normalize the vector for consistent scale by calculating the Euclidean norm (L2 norm) of the vector.
        // This calculates: ||v|| = √(v₁² + v₂² + v₃² + ... + vₙ²)
        // The result is a unit vector where ||v|| = 1
        //
        // Because we need consistent scale:
        // // Before normalization
        //  vector1 = [10, 20, 30]     // magnitude = √(100+400+900) = √1400 ≈ 37.4
        //  vector2 = [1, 2, 3]        // magnitude = √(1+4+9) = √14 ≈ 3.74
        // After normalization
        //  vector1 = [0.267, 0.535, 0.802]  // magnitude = 1.0
        //  vector2 = [0.267, 0.535, 0.802]  // magnitude = 1.0
        //
        // Embedding similarity should be about semantic direction, not vector size, i.e.
        // "cooking good sandwich" vs "cooking best sandwich" should be similar regardless of text length.
        //
        // Plus, when vectors are normalized, cosine similarity becomes simple dot product:
        // With normalized vectors:
        //  float similarity = Vector1.Dot(Vector2); // Simple and fast
        // Without normalization (more expensive)
        //  float similarity = Vector1.Dot(Vector2) / (Vector1.Magnitude * Vector2.Magnitude);
        //
        // Plus, it prevents Magnitude Bias as without normalization cosine similarity 
        // would be biased by magnitude differences. Normalization ensures fair comparison 
        // based on semantic direction only
        //  "cooking" → [large values]
        //  "cook" → [small values]
        var magnitude = (float)Math.Sqrt(embedding.Sum(x => x * x));
        // Basically, it is application of Pythagorean theorem extended to n dimensions:
        // 2D: distance = √(x² + y²)
        // 3D: distance = √(x² + y² + z²)
        // nD: distance = √(x₁² + x₂² + ... + xₙ²)
        // It gives the true geometric distance from the origin to the point in n-dimensional space.
        //
        // Alternative  Norms (Less Common):
        // - L1 norm (Manhattan distance)
        //      var l1_norm = embedding.Sum(x => Math.Abs(x));
        //
        // - L∞ norm (Maximum norm)
        //      var inf_norm = embedding.Max(x => Math.Abs(x));
        for (int i = 0; i < embedding.Length; i++)
        {
            embedding[i] /= magnitude;
        }
        // So here we get:
        // Before Normalization:
        //  "fix translation" → [0.8, -0.3, 1.2, 0.5] // magnitude = 1.62
        //  "bad translation" → [2.4, -0.9, 3.6, 1.5] // magnitude = 4.86

        // After Normalization:
        //  "fix translation" → [0.49, -0.19, 0.74, 0.31] // magnitude = 1.0
        //  "bad translation" → [0.49, -0.19, 0.74, 0.31] // magnitude = 1.0

        return Task.FromResult(embedding);
    }

    // This method is taken from chatbot.js to be very similar to let Simple Embedding Service work at all!
    private int GetHashCode(string str)
    {
        int hash = 0;
        if (str.Length == 0)
            return hash;

        for (int i = 0; i < str.Length; i++)
        {
            char c = str[i];
            hash = ((hash << 5) - hash) + c;
            hash = hash & hash; // Convert to 32bit integer
        }
        return Math.Abs(hash);
    }

    // This method is taken from chatbot.js to be very similar to let Simple Embedding Service work at all!
    private Func<double> SeededRandom(double initialSeed)
    {
        double seed = initialSeed;
        return () =>
        {
            seed = (seed * 9301.0 + 49297.0) % 233280.0;
            return seed / 233280.0;
        };
    }

    /// <summary>
    /// Normalize text for consistent embedding generation
    /// </summary>
    private string NormalizeText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // Convert to lowercase and trim whitespace
        return text.ToLowerInvariant().Trim();
    }

    public async Task<float[][]> GetEmbeddingsAsync(IEnumerable<string> texts)
    {
        var tasks = texts.Select(GetEmbeddingAsync);
        return await Task.WhenAll(tasks);
    }

    public void Dispose()
    {
        // Nothing to dispose
    }
}
