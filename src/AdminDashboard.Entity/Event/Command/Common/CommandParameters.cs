using AdminDashboard.Entity.Event.Base;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Event.Command;

public class CommandParameters<T> : TriggerEvent
{
    [JsonPropertyName("command")]
    public CommandType Command { get; set; }

    [JsonPropertyName("is_single")]
    public bool IsSingle { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("data_colection")]
    public IEnumerable<T> DataCollection { get; set; }
}