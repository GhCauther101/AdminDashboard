using AdminDashboard.Entity.Event.Base;
using System.Text.Json.Serialization;

namespace AdminDashboard.Entity.Event.Querying;

public class QueryParameters<T> : TriggerEvent
{
    [JsonPropertyName("functionality")]
    public QueryParameterFunctionality Functionality { get; set; }

    [JsonPropertyName("range_start")]
    public int RangeStart { get; set; }

    [JsonPropertyName("range_width")]
    public int RangeWidth { get; set; }

    [JsonPropertyName("last_width")]
    public int LastWidth { get; set; }

    [JsonPropertyName("entity_id")]
    public T EntityId { get; set; }

    [JsonPropertyName("entities_group")]
    public IEnumerable<T> EntitiesGroup { get; set; }

    public bool IsValid()
    {
        bool isSingleEnabled()
        {
            if (EntityId is int id && id > 0)
                return true;
            else return false;
        };

        bool isGroupEnabled()
        {
            if (EntitiesGroup.First() is int id && EntitiesGroup.Count() > 0)
                return true;
            else return false;
        };

        bool result = Functionality switch
        {
            QueryParameterFunctionality.GET_ALL => true,
            QueryParameterFunctionality.PAGE => (RangeStart > 0) && (RangeWidth > 0),
            QueryParameterFunctionality.SINGLE => isSingleEnabled(),
            QueryParameterFunctionality.GROUP => isGroupEnabled()
        };

        return result;
    }
}