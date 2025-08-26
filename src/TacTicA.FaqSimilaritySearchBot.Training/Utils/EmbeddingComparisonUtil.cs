using TacTicA.FaqSimilaritySearchBot.Training.Services;
using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;

namespace TacTicA.FaqSimilaritySearchBot.Training.Utils;

/// <summary>
/// Utility class to compare the performance of different embedding services
/// </summary>
public class EmbeddingComparisonUtil
{
    public static async Task CompareEmbeddingServices()
    {
        Console.WriteLine("=== Embedding Services Comparison ===\n");
        
        // Test queries
        var testQueries = new[]
        {
            "How do I make a super sandwich?",
            "How do i make a Russian salad?"
        };

        // Create default embedding settings (384 dimensions)
        var embeddingSettings = Options.Create(new EmbeddingSettings 
        { 
            EmbeddingDimension = 384 
        });

        // Initialize both services with configuration
        var simpleService = new SimpleEmbeddingService(embeddingSettings);
        var tfidfService = new TfIdfEmbeddingService(embeddingSettings);
        
        // Initialize TF-IDF with sample [Chromium codebase] corpus
        var questionsCorpus = new[]
        {
            "How do I make a super sandwich?",
            "How do i make a Russian salad?"
        };
        
        tfidfService.InitializeWithCorpus(questionsCorpus);

        Console.WriteLine("Test Queries:");
        for (int i = 0; i < testQueries.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {testQueries[i]}");
        }
        Console.WriteLine();

        // Generate embeddings for test queries
        Console.WriteLine("Generating embeddings with both services...\n");
        
        var simpleEmbeddings = new Dictionary<string, float[]>();
        var tfidfEmbeddings = new Dictionary<string, float[]>();
        
        foreach (var query in testQueries)
        {
            simpleEmbeddings[query] = await simpleService.GetEmbeddingAsync(query);
            tfidfEmbeddings[query] = await tfidfService.GetEmbeddingAsync(query);
        }

        // Compare similarity scores between related queries
        var comparisons = new[]
        {
            ("How do I make a super sandwich?", "How do I make a perfect sandwich?"),
            ("How do I make a delicious sandwich?", "How do I make a yummy sandwich?"),
            ("How do i make a Russian salad?", "How do i make a salad popular in Russia?") // Less related
        };

        Console.WriteLine("=== Similarity Comparisons ===\n");
        
        foreach (var (query1, query2) in comparisons)
        {
            var simpleSimilarity = CosineSimilarity(simpleEmbeddings[query1], simpleEmbeddings[query2]);
            var tfidfSimilarity = CosineSimilarity(tfidfEmbeddings[query1], tfidfEmbeddings[query2]);
            
            Console.WriteLine($"Query 1: {query1}");
            Console.WriteLine($"Query 2: {query2}");
            Console.WriteLine($"Simple Service Similarity: {simpleSimilarity:F4}");
            Console.WriteLine($"TF-IDF Service Similarity: {tfidfSimilarity:F4}");
            Console.WriteLine($"Difference: {Math.Abs(tfidfSimilarity - simpleSimilarity):F4}");
            Console.WriteLine(new string('-', 60));
        }

        // Test semantic grouping
        Console.WriteLine("\n=== Semantic Grouping Test ===");
        Console.WriteLine("Finding most similar query to: 'How do I make a super sandwich?'\n");
        
        var targetQuery = "How do I make a super sandwich?";
        var targetSimple = simpleEmbeddings[targetQuery];
        var targetTfidf = tfidfEmbeddings[targetQuery];
        
        var simpleResults = testQueries.Where(q => q != targetQuery)
            .Select(q => new { Query = q, Similarity = CosineSimilarity(targetSimple, simpleEmbeddings[q]) })
            .OrderByDescending(r => r.Similarity)
            .ToList();
            
        var tfidfResults = testQueries.Where(q => q != targetQuery)
            .Select(q => new { Query = q, Similarity = CosineSimilarity(targetTfidf, tfidfEmbeddings[q]) })
            .OrderByDescending(r => r.Similarity)
            .ToList();

        Console.WriteLine("Simple Service Results:");
        foreach (var result in simpleResults)
        {
            Console.WriteLine($"  {result.Similarity:F4} - {result.Query}");
        }
        
        Console.WriteLine("\nTF-IDF Service Results:");
        foreach (var result in tfidfResults)
        {
            Console.WriteLine($"  {result.Similarity:F4} - {result.Query}");
        }

        Console.WriteLine("\n=== Summary ===");
        Console.WriteLine("TF-IDF Service should show:");
        Console.WriteLine("- Higher similarity for semantically related queries");
        Console.WriteLine("- Better grouping of [Chromium codebase]-related terms");  
        Console.WriteLine("- More meaningful similarity scores based on keyword overlap");
        Console.WriteLine("\nSimple Service shows:");
        Console.WriteLine("- Random similarity scores based on text hash");
        Console.WriteLine("- No semantic understanding");
        Console.WriteLine("- Results may vary but won't reflect actual meaning");
        
        // Cleanup
        simpleService.Dispose();
        tfidfService.Dispose();
    }
    
    private static float CosineSimilarity(float[] a, float[] b)
    {
        if (a.Length != b.Length) return 0;

        double dotProduct = 0;
        double normA = 0;
        double normB = 0;

        for (int i = 0; i < a.Length; i++)
        {
            dotProduct += a[i] * b[i];
            normA += a[i] * a[i];
            normB += b[i] * b[i];
        }

        if (normA == 0 || normB == 0) return 0;
        return (float)(dotProduct / (Math.Sqrt(normA) * Math.Sqrt(normB)));
    }
}
