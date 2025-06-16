using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class PaymenntCommandResult : CommandResult<Payment>
{
    public PaymenntCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public PaymenntCommandResult(CommandType command, bool isSuccess)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        this.Command = command;
        this.IsSuccess = isSuccess;
    }
}