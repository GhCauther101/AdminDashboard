using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;

namespace AdminDashboard.Contracts.Repository;

public interface IClientRepository : IRepository
{
    public Task<ClientQueryResult> Get(ClientQueryParameters queryParameters);

    public Task<QueryPagerResult> GetPager();

    public void CreateClient(ClientCommandParameters commandParameters);

    public void UpdateClient(ClientCommandParameters commandParameters);

    public void DeleteClient(ClientCommandParameters commandParameters);
}