using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class PaymentCommandResult : CommandResult<Client>
{
    public PaymentCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public PaymentCommandResult(CommandType command, bool isSuccess, Exception exception = null)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        this.Command = command;
        this.IsSuccess = isSuccess;
        this.Exception = exception;
    }
}