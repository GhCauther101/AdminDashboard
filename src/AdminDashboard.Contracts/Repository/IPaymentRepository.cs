using AdminDashboard.Entity.Event.Command;
using AdminDashboard.Entity.Event.Querying.Common;
using AdminDashboard.Entity.Event.Querying;

namespace AdminDashboard.Contracts.Repository;

public interface IPaymentRepository : IRepository
{
    public int PaymentsCount { get; }

    public decimal TotalBill { get; }

    public Task<PaymentQueryResult> Get(PaymentQueryParameters<Guid> queryParameters);

    public Task<QueryPagerResult> GetPager();

    public void CreatePayment(PaymentCommandParameters commandParameters);

    public void UpdatePayment(PaymentCommandParameters commandParameters);

    public void DeletePayment(PaymentCommandParameters commandParameters);
}