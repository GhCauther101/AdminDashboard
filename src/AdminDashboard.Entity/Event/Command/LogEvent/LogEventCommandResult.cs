using AdminDashboard.Entity.Event.Base;
using AdminDashboard.Entity.Event.Command.Common;

namespace AdminDashboard.Entity.Event.Command;

public class LogEventCommandResult : CommandResult<TriggerEvent>
{
    public LogEventCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
    }

    public LogEventCommandResult(CommandType command, bool isSuccess)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        Command = command;
        IsSuccess = isSuccess;
    }
}