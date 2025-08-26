namespace TacTicA.FaqSimilaritySearchBot.Training.Configuration;

/// <summary>
/// Configuration settings for data processing
/// </summary>
public class ProcessingSettings
{
    /// <summary>
    /// Maximum tokens per text chunk
    /// </summary>
    public int MaxTokensPerChunk { get; set; } = 500;
    
    /// <summary>
    /// Similarity threshold for matching
    /// </summary>
    public double SimilarityThreshold { get; set; } = 0.90;
    
    /// <summary>
    /// Number of top results to return
    /// </summary>
    public int TopKResults { get; set; } = 5;
    
    /// <summary>
    /// Maximum number of document chunks to process
    /// </summary>
    public int MaxDocumentChunks { get; set; } = 10000;
}
