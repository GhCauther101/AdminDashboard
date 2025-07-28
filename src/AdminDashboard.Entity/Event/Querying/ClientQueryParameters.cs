namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryParameters : QueryParameters<Guid>
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
        Guid entityId = default,
        IEnumerable<Guid> entitiesGroup = null)
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