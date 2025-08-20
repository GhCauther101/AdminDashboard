using AdminDashboard.Entity.Event.Base;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Event.Querying;

public class QueryResult<T> : TriggerEvent
{
    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("entity")]
    public T Entity { get; set; }

    [JsonPropertyName("range")]
    public IEnumerable<T> Range { get; set; }

    [JsonPropertyName("exception")]
    public Exception Exception { get; set; }
}