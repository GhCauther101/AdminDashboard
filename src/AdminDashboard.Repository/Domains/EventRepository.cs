using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Base;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AdminDashboard.Repository.Domains;

public class EventRepository : RepositoryBase<TriggerEvent>, IEventRepository
{
    public EventRepository(IDbContextBus context) : base(context)
    { }

    public void CreateEvent(TriggerEventCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public void CreateEvent(object commandParameters)
    {
        throw new NotImplementedException();
    }

    public void DeleteEvent(TriggerEventCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public void DeleteEvent(Guid eventGlobalId)
    {
        throw new NotImplementedException();
    }

    public async Task<TriggerEventQueryResult> Get(TriggerEventQueryParameters queryParameters)
    {
        TriggerEventQueryResult triggerEventQueryResult = default;

        if (queryParameters.IsValid())
            return triggerEventQueryResult;

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                triggerEventQueryResult = new TriggerEventQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
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

                triggerEventQueryResult = new TriggerEventQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = clientPage.Count > 0,
                    Range = clientPage
                };
                break;
            case QueryParameterFunctionality.SINGLE:
                var entity = await FindByCondition(entity => entity.Id.Equals(queryParameters.EntityId), DbContextDomain.IDENTITY, false)
                    .SingleOrDefaultAsync();

                triggerEventQueryResult = new TriggerEventQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = entity is Client,
                    Entity = entity
                };
                break;
        }

        return triggerEventQueryResult;
    }

    public Task<object> Get(object queryParameters)
    {
        throw new NotImplementedException();
    }
}
