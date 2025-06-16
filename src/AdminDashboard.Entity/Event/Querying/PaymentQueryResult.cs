using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying;

public class PaymentQueryResult : QueryResult<Payment>
{
    public PaymentQueryResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public PaymentQueryResult(
        bool isSuccess,
        Payment payment = null,
        IEnumerable<Payment> range = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Entity = payment;
        this.Range = range;
        this.Exception = exception;
    }
}