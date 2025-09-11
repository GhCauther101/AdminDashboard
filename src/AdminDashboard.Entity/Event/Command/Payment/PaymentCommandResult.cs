using AdminDashboard.Entity.Event.Command.Common;
using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class PaymentCommandResult : CommandResult<Payment>
{
    public PaymentCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
    }

    public PaymentCommandResult(CommandType command, bool isSuccess, Exception ex = null)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        Command = command;
        IsSuccess = isSuccess;
        Exception = ex;
    }
}