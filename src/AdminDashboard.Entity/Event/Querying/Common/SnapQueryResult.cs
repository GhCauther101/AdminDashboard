using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class SnapQueryResult : QueryResult<Snap>
{
    public SnapQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
    }

    public SnapQueryResult(
        bool isSuccess,
        Snap snap = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        Entity = snap;
    }
}