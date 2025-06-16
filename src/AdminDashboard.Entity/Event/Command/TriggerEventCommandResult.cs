using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Command;

public class TriggerEventCommandResult : CommandResult<TriggerEvent>
{
    public TriggerEventCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public TriggerEventCommandResult(CommandType command, bool isSuccess)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        this.Command = command;
        this.IsSuccess = isSuccess;
    }
}