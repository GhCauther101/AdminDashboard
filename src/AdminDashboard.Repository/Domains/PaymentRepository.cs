using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying.Common;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AdminDashboard.Repository.Domains;

public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
{
    public PaymentRepository(IDbContextBus dbContextBus) : base(dbContextBus)
    { }

    public int PaymentsCount => base.GetDbContext(DbContextDomain.IDENTITY).Set<Payment>().Count();

    public decimal TotalBill => base.GetDbContext(DbContextDomain.IDENTITY).Set<Payment>().Sum(p => p.Bill);

    public void CreatePayment(PaymentCommandParameters commandParameters)
    {
        Create(commandParameters.Data, DbContextDomain.IDENTITY);
    }
    
    public void UpdatePayment(PaymentCommandParameters commandParameters)
    {
        Update(commandParameters.Data, DbContextDomain.IDENTITY);
    }

    public void DeletePayment(PaymentCommandParameters commandParameters)
    {
        Delete(commandParameters.Data, DbContextDomain.IDENTITY);
    }    

    public async Task<PaymentQueryResult> Get(PaymentQueryParameters<Guid> queryParameters)
    {
        PaymentQueryResult paymentQueryResult = default;

        if (!queryParameters.IsValid())
            return paymentQueryResult;

        switch (queryParameters.Functionality)
        {
            case QueryParameterFunctionality.GET_ALL:
                var allClients = await FindAll(DbContextDomain.IDENTITY, false)
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
                var clientPage = await FindAll(DbContextDomain.IDENTITY, false)
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
                var entity = await FindByCondition(entity => entity.PaymentId.Equals(queryParameters.EntityId), DbContextDomain.IDENTITY, false)
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
            case QueryParameterFunctionality.CLIENT_HISTORY:
                var historyList = await FindByCondition(entity => entity.SourceClientId.Equals(queryParameters.EntityId.ToString()) || entity.DestinationClientId.Equals(queryParameters.EntityId.ToString()), DbContextDomain.IDENTITY, false)
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
            case QueryParameterFunctionality.LAST:
                var lastPayment = await FindAll(DbContextDomain.IDENTITY, false)
                    .OrderByDescending(e => e.ProcessTime)
                    .Take(queryParameters.LastWidth)
                    .SelectPayments()
                    .ToListAsync();

                paymentQueryResult = new PaymentQueryResult
                {
                    Id = Guid.NewGuid(),
                    TriggerTime = DateTime.Now,
                    IsSuccess = lastPayment.Count > 0,
                    Range = lastPayment
                };
                break;
        }

        return paymentQueryResult;
    }

    public async Task<QueryPagerResult> GetPager()
    {
        var pager = GetRepositoryPager(DbContextDomain.IDENTITY);
        return new QueryPagerResult(true, pager);
    }
}