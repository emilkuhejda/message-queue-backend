using System.Text.Json.Serialization;

namespace MessageQueue.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ErrorCode
    {
        None = 0
    }
}
