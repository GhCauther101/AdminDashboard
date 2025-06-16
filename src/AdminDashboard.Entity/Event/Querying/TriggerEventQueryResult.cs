using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Querying;

public class TriggerEventQueryResult : QueryResult<TriggerEvent>
{
    public TriggerEventQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public TriggerEventQueryResult(
        bool isSuccess,
        TriggerEvent triggerEvent = null,
        IEnumerable<TriggerEvent> range = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Entity = triggerEvent;
        this.Range = range;
        this.Exception = exception;
    }
}