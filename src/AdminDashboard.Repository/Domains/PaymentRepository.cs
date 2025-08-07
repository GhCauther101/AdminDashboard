using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdminDashboard.Repository.Domains;

public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
{
    public PaymentRepository(IDbContextBus dbContextBus) : base(dbContextBus)
    { }

    public void CreatePayment(PaymentCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.REPOSITORY);
    }
    
    public void UpdatePayment(PaymentCommandParameters commandParameters)
    {
        Update(commandParameters.Data, DbContextDomain.REPOSITORY);
    }

    public void DeletePayment(PaymentCommandParameters commandParameters)
    {
        Delete(commandParameters.Data, DbContextDomain.REPOSITORY);
    }    

    public async Task<PaymentQueryResult> Get(PaymentQueryParameters<Guid> queryParameters)
    {
        PaymentQueryResult paymentQueryResult = default;

        if (!queryParameters.IsValid())
            return paymentQueryResult;

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.REPOSITORY, false)
                    .OrderByDescending(x => x.ProcessTime)
                    .SelectPayments()
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
                    .OrderByDescending(x => x.ProcessTime)
                    .Skip((queryParameters.RangeStart - 1) * queryParameters.RangeWidth)
                    .Take(queryParameters.RangeWidth)
                    .SelectPayments()
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
                var entity = await FindByCondition(entity => entity.PaymentId.Equals(queryParameters.EntityId), DbContextDomain.REPOSITORY, false)
                    .SelectPayments()
                    .SingleOrDefaultAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = entity is Client,
                    Entity = entity
                };
                break;
            case QueryParameterFunctionality.CLIENT:
                var historyList = await FindByCondition(entity => entity.SourceClientId.Equals(queryParameters.EntityId.ToString()) || entity.DestinationClientId.Equals(queryParameters.EntityId.ToString()), DbContextDomain.REPOSITORY, false)
                    .OrderByDescending(e =>e.ProcessTime)
                    .SelectPayments()
                    .ToListAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = historyList.Count > 0,
                    Range = historyList
                };
                break;
        }

        return paymentQueryResult;
    }

    public async Task<QueryPagerResult> GetPager()
    {
        var pager = GetRepositoryPager(DbContextDomain.REPOSITORY);
        return new QueryPagerResult(true, pager);
    }
}

public static class RepositoryHelper
{
    public static IQueryable<Payment> SelectPayments(this IQueryable<Payment> payments)
    {
        return payments.Select(p => new Payment
        {
            PaymentId = p.PaymentId,
            Bill = p.Bill,
            ProcessTime = p.ProcessTime,
            SourceClient = new Client { Id = p.SourceClient.Id, UserName = p.SourceClient.UserName },
            DestinationClient = new Client { Id = p.DestinationClient.Id, UserName = p.DestinationClient.UserName }
        });
    }
}