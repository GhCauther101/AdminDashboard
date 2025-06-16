namespace AdminDashboard.Entity.Event.Querying;

public class TriggerEventQueryParameters : QueryParameters<int>
{
    public TriggerEventQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public TriggerEventQueryParameters(
        QueryParameterFunctionality functionality,
        int rangeStart = 0 ,
        int rangeWidth = 0,
        int entityId = 0,
        IEnumerable<int> entitiesGroup = null)
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