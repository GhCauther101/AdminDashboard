using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Querying;

public class LogEventQueryResult : QueryResult<TriggerEvent>
{
    public LogEventQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public LogEventQueryResult(
        bool isSuccess,
        TriggerEvent triggerEvent = null,
        IEnumerable<TriggerEvent> range = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        Entity = triggerEvent;
        Range = range;
        Exception = exception;
    }
}