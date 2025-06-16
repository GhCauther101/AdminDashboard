namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryParameters : QueryParameters<int>
{
    public ClientQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }
}