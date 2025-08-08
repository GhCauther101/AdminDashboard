using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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
        {
            return clientQueryResult;
        }

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderBy(c => c.UserName)
                    .AsNoTracking()
                    .ToListAsync();

                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = allClients.Count > 0,
                    Range = allClients
                };
                break;
            case QueryParameterFunctionality.PAGE:
                var clientPage = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderBy(c => c.Id)
                    .Skip((queryParameters.RangeStart - 1) * queryParameters.RangeWidth)
                    .Take(queryParameters.RangeWidth)
                    .AsNoTracking()
                    .ToListAsync();

                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = clientPage.Count > 0,
                    Range = clientPage
                };
                break;
            case QueryParameterFunctionality.SINGLE:
                var entity = await FindByCondition(entity => entity.Id.Equals(queryParameters.EntityId.ToString()), DbContextDomain.IDENTITY, false)
                    .Include(c => c.SentPayments)
                    .Include(c => c.RecievedPayments)
                    .AsNoTracking()
                    .SingleOrDefaultAsync();
                
                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = entity is Client,
                    Entity = entity
                };
                break;
            case QueryParameterFunctionality.GET_VOLUMED:
                var volumedClients = await FindAll(DbContextDomain.IDENTITY, false)
                    .Include(c => c.SentPayments)
                    .Include(c => c.RecievedPayments)
                    .Select(c => new { PaymentSum = c.SumPayments(), ClientEntity = c })
                    .ToListAsync();
                volumedClients.OrderByDescending(x => x.PaymentSum);
                clientQueryResult = new ClientQueryResult
                {
                    IsSuccess = volumedClients.Count > 0,
                    Range = volumedClients.Select(x => x.ClientEntity).ToList()
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