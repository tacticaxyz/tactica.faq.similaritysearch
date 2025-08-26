namespace TacTicA.FaqSimilaritySearchBot.Training.Configuration;

/// <summary>
/// Configuration settings for embedding services
/// </summary>
public class EmbeddingSettings
{
    /// <summary>
    /// Path to the embedding model file
    /// </summary>
    public string ModelPath { get; set; } = "models/model.onnx";
    
    /// <summary>
    /// Maximum sequence length for input text
    /// </summary>
    public int MaxSequenceLength { get; set; } = 512;
    
    /// <summary>
    /// Dimension of the embedding vectors
    /// </summary>
    public int EmbeddingDimension { get; set; } = 384;
}
