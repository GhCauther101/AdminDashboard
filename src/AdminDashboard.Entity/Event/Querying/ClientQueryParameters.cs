namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryParameters : QueryParameters<int>
{
    public ClientQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public ClientQueryParameters(
        QueryParameterFunctionality functionality, 
        int rangeStart,
        int rangeWidth,
        int entityId,
        IEnumerable<int> entitiesGroup)
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