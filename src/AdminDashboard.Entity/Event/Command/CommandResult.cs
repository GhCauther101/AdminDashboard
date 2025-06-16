using AdminDashboard.Entity.Event.Base;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Event.Command;

public class CommandResult<T> : TriggerEvent
{
    [JsonPropertyName("command")]
    public CommandType Command { get; set; }


    [JsonPropertyName("is_success")]
    public bool IsSuccess { get; set; }

    [JsonPropertyName("exception")]
    public Exception Exception { get; set; }

}