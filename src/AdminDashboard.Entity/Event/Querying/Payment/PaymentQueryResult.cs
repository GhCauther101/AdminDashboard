using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class PaymentQueryResult : QueryResult<Payment>
{
    public PaymentQueryResult()
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
    }

    public PaymentQueryResult(
        bool isSuccess,
        Payment payment = null,
        IEnumerable<Payment> range = null,
        Exception exception = null)
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        TriggerClusterId = Guid.NewGuid();
        Entity = payment;
        Range = range;
        Exception = exception;
    }
}