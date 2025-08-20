using AdminDashboard.Entity.Event.Querying.Common;

namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryParameters<T> : QueryParameters<T>
{
    public ClientQueryParameters()
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
    }

    public ClientQueryParameters(
        QueryParameterFunctionality functionality, 
        int rangeStart = 0,
        int rangeWidth = 0,
        int lastWidth = 0,
        T entityId = default,
        IEnumerable<T> entitiesGroup = null)
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
        Functionality = functionality;
        RangeStart = rangeStart;
        RangeWidth = rangeWidth;
        EntityId = entityId;
        EntitiesGroup = entitiesGroup;
    }
}