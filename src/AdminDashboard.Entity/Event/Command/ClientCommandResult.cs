using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class ClientCommandResult : CommandResult<Client>
{
    public ClientCommandResult()
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
    }

    public ClientCommandResult(CommandType command, bool isSuccess)
    {
        this.Id = Guid.NewGuid();
        this.TriggerTime = DateTime.Now;
        this.TriggerClusterId = Guid.NewGuid();
        this.Command = command;
        this.IsSuccess = isSuccess;
    }
}