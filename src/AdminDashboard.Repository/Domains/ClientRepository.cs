using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Domains;

public class ClientRepository : RepositoryBase<Client>, IClientRepository
{
    public ClientRepository(IDbContextBus dbContextBus) : base(dbContextBus)
    {}

    public void CreateClient(ClientCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public void UpdateClient(ClientCommandParameters commandParameters)
    {
        Update(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public void DeleteClient(ClientCommandParameters commandParameters)
    {
        Delete(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public async Task<ClientQueryResult> Get(ClientQueryParameters<string> queryParameters)
    {   
        ClientQueryResult clientQueryResult = default;

        if (!queryParameters.IsValid())
            return clientQueryResult;

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderBy(x => x.UserName)
                    .ToListAsync();

                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = allClients.Count > 0,
                    Range = allClients
                };
                break;
            case QueryParameterFunctionality.PAGE:
                var clientPage = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderBy(x => x.Id)
                    .Skip((queryParameters.RangeStart - 1) * queryParameters.RangeWidth)
                    .Take(queryParameters.RangeWidth)
                    .ToListAsync();

                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = clientPage.Count > 0,
                    Range = clientPage
                };
                break;
            case QueryParameterFunctionality.SINGLE:
                var entity = await FindByCondition(entity => entity.Id.Equals(queryParameters.EntityId.ToString()), DbContextDomain.IDENTITY, false)
                    .SingleOrDefaultAsync();
                
                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = entity is Client,
                    Entity = entity
                };
                break;
        }

        return clientQueryResult;
    }    

    public async Task<QueryPagerResult> GetPager()
    {
        var pager = GetRepositoryPager(DbContextDomain.REPOSITORY);
        return new QueryPagerResult(true, pager:pager);
    }
}