using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class PaymentQueryResult : QueryResult<Payment>
{
    public PaymentQueryResult()
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
    }

    public PaymentQueryResult(
        bool isSuccess,
        Payment payment = null,
        IEnumerable<Payment> range = null,
        Exception exception = null)
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        Entity = payment;
        Range = range;
        Exception = exception;
    }
}