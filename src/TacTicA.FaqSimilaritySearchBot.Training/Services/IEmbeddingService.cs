using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Text.RegularExpressions;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;
public interface IEmbeddingService
{
    Task<float[]> GetEmbeddingAsync(string text);
    Task<float[][]> GetEmbeddingsAsync(IEnumerable<string> texts);
    void Dispose();
}
