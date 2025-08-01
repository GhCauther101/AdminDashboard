namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryParameters<T> : QueryParameters<T>
{
    public ClientQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public ClientQueryParameters(
        QueryParameterFunctionality functionality, 
        int rangeStart = 0,
        int rangeWidth = 0,
        int lastWidth = 0,
        T entityId = default,
        IEnumerable<T> entitiesGroup = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Functionality = functionality;
        base.RangeStart = rangeStart;
        base.RangeWidth = rangeWidth;
        base.EntityId = entityId;
        base.EntitiesGroup = entitiesGroup;
    }
}