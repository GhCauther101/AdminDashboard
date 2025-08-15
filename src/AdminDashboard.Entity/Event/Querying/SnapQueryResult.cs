using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class SnapQueryResult : QueryResult<Snap>
{
    public SnapQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public SnapQueryResult(
        bool isSuccess,
        Snap snap = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Entity = snap;
    }
}