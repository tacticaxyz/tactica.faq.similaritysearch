using System.Text.Json.Serialization;

namespace TacTicA.FaqSimilaritySearchBot.Shared.Models;

public class ChatBotResponse
{
    [JsonPropertyName("answer")]
    public string Answer { get; set; } = string.Empty;

    [JsonPropertyName("sources")]
    public List<SearchResult> Sources { get; set; } = new();

    [JsonPropertyName("confidence")]
    public float Confidence { get; set; }

    [JsonPropertyName("responseType")]
    public ResponseType ResponseType { get; set; }

    [JsonPropertyName("processingTimeMs")]
    public long ProcessingTimeMs { get; set; }
}