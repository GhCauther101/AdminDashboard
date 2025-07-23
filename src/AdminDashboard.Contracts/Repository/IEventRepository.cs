using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;

namespace AdminDashboard.Contracts.Repository;

public interface IEventRepository : IRepository
{
    public Task<TriggerEventQueryResult> Get(TriggerEventQueryParameters queryParameters);

    public Task<QueryPagerResult> GetPager();

    public void CreateEvent(TriggerEventCommandParameters commandParameters);

    public void DeleteEvent(TriggerEventCommandParameters commandParameters);
}