using System.Numerics.Tensors;

namespace TacTicA.FaqSimilaritySearchBot.Shared.Utils;

public static class VectorUtils
{
    public static float CosineSimilarity(ReadOnlySpan<float> vector1, ReadOnlySpan<float> vector2)
    {
        if (vector1.Length != vector2.Length)
            throw new ArgumentException("Vectors must have the same length");

        var dotProduct = TensorPrimitives.Dot(vector1, vector2);
        var magnitude1 = TensorPrimitives.Norm(vector1);
        var magnitude2 = TensorPrimitives.Norm(vector2);

        if (magnitude1 == 0 || magnitude2 == 0)
            return 0;

        return dotProduct / (magnitude1 * magnitude2);
    }

    public static List<(int Index, float Similarity)> FindTopMatches(
        ReadOnlySpan<float> queryVector, 
        IEnumerable<float[]> vectors, 
        int topK = 5)
    {
        var similarities = new List<(int Index, float Similarity)>();
        
        var index = 0;
        foreach (var vector in vectors)
        {
            var similarity = CosineSimilarity(queryVector, vector);
            similarities.Add((index, similarity));
            index++;
        }

        return similarities
            .OrderByDescending(x => x.Similarity)
            .Take(topK)
            .ToList();
    }

    public static float[] NormalizeVector(ReadOnlySpan<float> vector)
    {
        var magnitude = TensorPrimitives.Norm(vector);
        if (magnitude == 0)
            return vector.ToArray();

        var normalized = new float[vector.Length];
        for (int i = 0; i < vector.Length; i++)
        {
            normalized[i] = vector[i] / magnitude;
        }
        return normalized;
    }
}
