using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryResult : QueryResult<Client>
{
    public ClientQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public ClientQueryResult(
        bool isSuccess,
        Client client = null,
        IEnumerable<Client> range = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Entity = client;
        this.Range = range;
        this.Exception = exception;
    }
}