using TacTicA.FaqSimilaritySearchBot.Shared.Models;
using System.Text.Json;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;

public interface IDataProcessingService
{
    Task<List<QuestionAnswerPair>> LoadQuestionsAndAnswersAsync(string filePath);
    Task<List<string>> LoadWikiLinksAsync(string filePath);
    Task<List<DocumentChunk>> ProcessWikiContentAsync(IEnumerable<string> wikiLinks);
    Task SaveProcessedDataAsync(string outputPath, List<QuestionAnswerPair> qaData, List<DocumentChunk> documentChunks);
}