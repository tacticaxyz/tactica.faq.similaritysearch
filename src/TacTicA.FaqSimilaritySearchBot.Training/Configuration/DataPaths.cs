namespace TacTicA.FaqSimilaritySearchBot.Training.Configuration;

/// <summary>
/// Configuration settings for data file paths
/// </summary>
public class DataPaths
{
    /// <summary>
    /// Path to the questions and answers file
    /// </summary>
    public string QuestionsAnswersFile { get; set; } = "data/questions_answers.txt";
    
    /// <summary>
    /// Path to the wiki links file
    /// </summary>
    public string WikiLinksFile { get; set; } = "data/wiki_links.txt";
    
    /// <summary>
    /// Output directory for processed data
    /// </summary>
    public string OutputDirectory { get; set; } = "wwwroot/data";
    
    /// <summary>
    /// Directory containing exported content files
    /// </summary>
    public string ExportedContentDirectory { get; set; } = "data/exported-content";
}
