using AdminDashboard.Entity.Event.Base;
using AdminDashboard.Entity.Event.Command.Common;

namespace AdminDashboard.Entity.Event.Command;

public class LogEventCommandParameters : CommandParameters<TriggerEvent>
{
    public LogEventCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public LogEventCommandParameters(
        CommandType command,
        bool isSingle,
        TriggerEvent data = default,
        IEnumerable<TriggerEvent> dataCollection = default)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        Command = command;
        IsSingle = isSingle;
        Data = data;
        DataCollection = dataCollection;
    }
}