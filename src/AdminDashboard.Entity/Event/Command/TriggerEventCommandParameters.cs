using AdminDashboard.Entity.Event.Base;

namespace AdminDashboard.Entity.Event.Command;

public class TriggerEventCommandParameters : CommandParameters<TriggerEvent>
{
    public TriggerEventCommandParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public TriggerEventCommandParameters(
        CommandType command,
        bool isSingle,
        TriggerEvent data = default,
        IEnumerable<TriggerEvent> dataCollection = default)
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