using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class PaymentCommandResult : CommandResult<Payment>
{
    public PaymentCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public PaymentCommandResult(CommandType command, bool isSuccess, Exception ex = null)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        this.Command = command;
        this.IsSuccess = isSuccess;
        this.Exception = ex;
    }
}