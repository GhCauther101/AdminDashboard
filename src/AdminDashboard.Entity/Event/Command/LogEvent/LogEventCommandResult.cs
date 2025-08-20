using AdminDashboard.Entity.Event.Base;
using AdminDashboard.Entity.Event.Command.Common;

namespace AdminDashboard.Entity.Event.Command;

public class LogEventCommandResult : CommandResult<TriggerEvent>
{
    public LogEventCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public LogEventCommandResult(CommandType command, bool isSuccess)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        Command = command;
        IsSuccess = isSuccess;
    }
}