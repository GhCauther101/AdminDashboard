using AdminDashboard.Entity.Event.Querying.Common;

namespace AdminDashboard.Entity.Event.Querying;

public class PaymentQueryParameters<T> : QueryParameters<T>
{
    public PaymentQueryParameters()
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
    }

    public PaymentQueryParameters(
        QueryParameterFunctionality functionality,
        int rangeStart = 0,
        int rangeWidth = 0,
        int lastWidth = 0,
        T entityId = default,
        IEnumerable<T> entitiesGroup = null)
    {
        Id = Guid.NewGuid();
        TriggerTime = DateTime.Now;
        Functionality = functionality;
        RangeStart = rangeStart;
        RangeWidth = rangeWidth;
        EntityId = entityId;
        EntitiesGroup = entitiesGroup;
        LastWidth = lastWidth;
    }
}