using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TacTicA.FaqSimilaritySearchBot.Shared.Models;
using TacTicA.FaqSimilaritySearchBot.Training.Configuration;
using TacTicA.FaqSimilaritySearchBot.Training.Services;

namespace TacTicA.FaqSimilaritySearchBot.Training;

public class TrainingService
{
    private readonly IDataProcessingService _dataProcessingService;
    private readonly ILogger<TrainingService> _logger;
    private readonly DataPaths _dataPaths;

    public TrainingService(IDataProcessingService dataProcessingService, ILogger<TrainingService> logger, IOptions<DataPaths> dataPaths)
    {
        _dataProcessingService = dataProcessingService;
        _logger = logger;
        _dataPaths = dataPaths.Value;
    }

    public async Task RunAsync()
    {
        _logger.LogInformation("Starting training process...");

        // Use configured paths from appsettings.json
        var currentDirectory = Directory.GetCurrentDirectory();
        var qaFilePath = Path.IsPathRooted(_dataPaths.QuestionsAnswersFile) 
            ? _dataPaths.QuestionsAnswersFile 
            : Path.Combine(currentDirectory, _dataPaths.QuestionsAnswersFile);
        var wikiLinksFilePath = Path.IsPathRooted(_dataPaths.WikiLinksFile)
            ? _dataPaths.WikiLinksFile
            : Path.Combine(currentDirectory, _dataPaths.WikiLinksFile);
        var outputPath = Path.IsPathRooted(_dataPaths.OutputDirectory)
            ? _dataPaths.OutputDirectory
            : Path.Combine(currentDirectory, _dataPaths.OutputDirectory);

        // Process Q&A data
        _logger.LogInformation("Processing Q&A data...");
        var qaData = await _dataProcessingService.LoadQuestionsAndAnswersAsync(qaFilePath);

        // Process wiki content
        _logger.LogInformation("Processing wiki content...");
        var wikiLinks = await _dataProcessingService.LoadWikiLinksAsync(wikiLinksFilePath);
        var documentChunks = await _dataProcessingService.ProcessWikiContentAsync(wikiLinks);

        // Save processed data
        _logger.LogInformation("Saving processed data...");
        await _dataProcessingService.SaveProcessedDataAsync(outputPath, qaData, documentChunks);

        _logger.LogInformation("Training completed! Generated {QACount} Q&A embeddings and {ChunkCount} document chunks",
            qaData.Count, documentChunks.Count);
    }
}
