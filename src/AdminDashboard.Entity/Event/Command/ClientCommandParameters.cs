using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class ClientCommandParameters : CommandParameters<Client>
{
    public ClientCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public ClientCommandParameters(
        CommandType command, 
        bool isSingle, 
        Client data = default, 
        IEnumerable<Client> dataCollection = default)
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