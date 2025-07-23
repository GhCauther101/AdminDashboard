namespace AdminDashboard.Entity.Event.Querying;

public class QueryPagerParameters : QueryParameters<int>
{
    public QueryPagerParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }
}
