using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Command;

public class LogEventCommandParameters : CommandParameters<TriggerEvent>
{
    public LogEventCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
    }

    public LogEventCommandParameters(
        CommandType command,
        bool isSingle,
        TriggerEvent data = default,
        IEnumerable<TriggerEvent> dataCollection = default)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        Command = command;
        IsSingle = isSingle;
        Data = data;
        DataCollection = dataCollection;
    }
}