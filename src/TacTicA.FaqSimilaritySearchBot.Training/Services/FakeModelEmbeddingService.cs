using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System.Text.RegularExpressions;

namespace TacTicA.FaqSimilaritySearchBot.Training.Services;


public class FakeModelEmbeddingService : IEmbeddingService, IDisposable
{
    private readonly InferenceSession _session;
    private readonly Dictionary<string, int> _vocabulary;
    private readonly int _maxLength;
    private bool _disposed = false;

    public FakeModelEmbeddingService(string modelPath, int maxLength = 512)
    {
        _maxLength = maxLength;
        _session = new InferenceSession(modelPath);
        _vocabulary = LoadVocabulary(); // You'll need to provide vocabulary file
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
        // Tokenize the text
        var tokens = TokenizeText(text);
        var inputIds = tokens.Select(t => _vocabulary.GetValueOrDefault(t, _vocabulary["[UNK]"])).ToArray();
        
        // Pad or truncate to max length
        Array.Resize(ref inputIds, _maxLength);
        
        // Create attention mask
        var attentionMask = inputIds.Select(id => id != 0 ? 1 : 0).ToArray();

        // Create input tensors
        var inputIdsTensor = new DenseTensor<long>(inputIds.Select(id => (long)id).ToArray(), new[] { 1, _maxLength });
        var attentionMaskTensor = new DenseTensor<long>(attentionMask.Select(mask => (long)mask).ToArray(), new[] { 1, _maxLength });

        var inputs = new List<NamedOnnxValue>
        {
            NamedOnnxValue.CreateFromTensor("input_ids", inputIdsTensor),
            NamedOnnxValue.CreateFromTensor("attention_mask", attentionMaskTensor)
        };

        // Run inference
        using var results = _session.Run(inputs);
        var embeddings = results.First().AsTensor<float>();
        
        // Return the pooled output (CLS token embedding)
        var embedding = new float[embeddings.Dimensions[2]];
        for (int i = 0; i < embedding.Length; i++)
        {
            embedding[i] = embeddings[0, 0, i];
        }

        return embedding;
    }

    private string[] TokenizeText(string text)
    {
        // Simple tokenization - in production, use proper tokenizer
        text = text.ToLowerInvariant();
        text = Regex.Replace(text, @"[^\w\s]", " ");
        return text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    }

    private Dictionary<string, int> LoadVocabulary()
    {
        // Simplified vocabulary - in production, load from vocab.txt
        return new Dictionary<string, int>
        {
            ["[PAD]"] = 0,
            ["[UNK]"] = 1,
            ["[CLS]"] = 2,
            ["[SEP]"] = 3
        };
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