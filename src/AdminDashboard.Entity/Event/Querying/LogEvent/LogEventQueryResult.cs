using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Querying;

public class LogEventQueryResult : QueryResult<TriggerEvent>
{
    public LogEventQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
    }

    public LogEventQueryResult(
        bool isSuccess,
        TriggerEvent triggerEvent = null,
        IEnumerable<TriggerEvent> range = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        Entity = triggerEvent;
        Range = range;
        Exception = exception;
    }
}