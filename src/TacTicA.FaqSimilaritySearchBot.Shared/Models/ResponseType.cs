using System.Text.Json.Serialization;

namespace TacTicA.FaqSimilaritySearchBot.Shared.Models;

public enum ResponseType
{
    FAQ,
    RAG,
    Fallback
}
