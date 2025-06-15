using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Domains;

public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
{
    public PaymentRepository(IDbContextBus dbContextBus) : base(dbContextBus)
    { }

    public void CreatePayment(PaymentCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.REPOSITORY);
    }

    public void DeletePayment(PaymentCommandParameters commandParameters)
    {
        Delete(commandParameters.Data, DbContextDomain.REPOSITORY);
    }

    public void UpdatePayment(PaymentCommandParameters commandParameters)
    {
        Update(commandParameters.Data, DbContextDomain.REPOSITORY);
    }

    public async Task<PaymentQueryResult> Get(PaymentQueryParameters queryParameters)
    {
        PaymentQueryResult paymentQueryResult = default;

        if (queryParameters.IsValid())
            return paymentQueryResult;

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.REPOSITORY, false)
                    .OrderBy(x => x.Id)
                    .ToListAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = allClients.Count > 0,
                    Range = allClients
                };
                break;
            case QueryParameterFunctionality.PAGE:
                var clientPage = await FindAll(DbContextDomain.REPOSITORY, false)
                    .OrderBy(x => x.Id)
                    .Skip((queryParameters.RangeStart - 1) * queryParameters.RangeWidth)
                    .Take(queryParameters.RangeWidth)
                    .ToListAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = clientPage.Count > 0,
                    Range = clientPage
                };
                break;
            case QueryParameterFunctionality.SINGLE:
                var entity = await FindByCondition(entity => entity.Id.Equals(queryParameters.EntityId), DbContextDomain.REPOSITORY, false)
                    .SingleOrDefaultAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = entity is Client,
                    Entity = entity
                };
                break;
            case QueryParameterFunctionality.GROUP:
                var clientRange = await FindByCondition(entity => queryParameters.EntitiesGroup.Contains(entity.Id), DbContextDomain.REPOSITORY, false)
                    .OrderBy(entity => entity.Id)
                    .ToListAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = clientRange.Count > 0,
                    Range = clientRange
                };
                break;
        }

        return paymentQueryResult;
    }
}
