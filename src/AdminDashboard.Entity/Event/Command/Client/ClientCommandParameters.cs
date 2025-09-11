using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Command;

public class ClientCommandParameters : CommandParameters<Client>
{
    public ClientCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
    }

    public ClientCommandParameters(
        CommandType command, 
        bool isSingle, 
        Client data = default, 
        IEnumerable<Client> dataCollection = default)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        Command = command;
        IsSingle = isSingle;
        Data = data;
        DataCollection = dataCollection;
    }
}