using AdminDashboard.Entity.Event.Querying.Common;

namespace AdminDashboard.Entity.Event.Querying;

public class LogEventQueryParameters : QueryParameters<int>
{
    public LogEventQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
    }

    public LogEventQueryParameters(
        QueryParameterFunctionality functionality,
        int rangeStart = 0,
        int rangeWidth = 0,
        int entityId = 0,
        IEnumerable<int> entitiesGroup = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        Functionality = functionality;
        RangeStart = rangeStart;
        RangeWidth = rangeWidth;
        EntityId = entityId;
        EntitiesGroup = entitiesGroup;
    }
}