using System.Text.Json.Serialization;
using System.Text.Json;

namespace AdminDashboard.Entity.Event.Base;

public class TriggerEvent : IEntity
{
    public Guid Id { get; set; }
    
    public DateTime TriggerTime { get; set; }
    
    public Guid TriggerClusterId { get; set; }

    protected EventEntry Snap(bool indented = false)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = indented,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var snap = JsonSerializer.Serialize(this, options);

        return new EventEntry(Guid.NewGuid(), snap);
    }
}