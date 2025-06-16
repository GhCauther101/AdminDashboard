using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class PaymentCommandParameters : CommandParameters<Payment>
{
    public PaymentCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public PaymentCommandParameters(
        CommandType command,
        bool isSingle,
        Payment data = default,
        IEnumerable<Payment> dataCollection = default)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Command = command;
        base.IsSingle = isSingle;
        base.Data = data;
        base.DataCollection = dataCollection;
    }
}