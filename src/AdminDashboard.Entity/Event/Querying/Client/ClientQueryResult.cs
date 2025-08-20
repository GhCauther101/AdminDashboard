using AdminDashboard.Entity.Event.Querying.Common;
using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class ClientQueryResult : QueryResult<Client>
{
    public ClientQueryResult()
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
    }

    public ClientQueryResult(
        bool isSuccess,
        Client client = null,
        IEnumerable<Client> range = null,
        Exception exception = null)
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
        Entity = client;
        Range = range;
        Exception = exception;
    }
}