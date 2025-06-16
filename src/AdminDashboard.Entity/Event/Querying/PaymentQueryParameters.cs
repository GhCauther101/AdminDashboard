namespace AdminDashboard.Entity.Event.Querying;

public class PaymentQueryParameters : QueryParameters<int>
{
    public PaymentQueryParameters()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public PaymentQueryParameters(
        QueryParameterFunctionality functionality,
<<<<<<< HEAD
        int rangeStart,
        int rangeWidth,
        int entityId,
        IEnumerable<int> entitiesGroup)
=======
        int rangeStart = 0,
        int rangeWidth = 0,
        int entityId = 0,
        IEnumerable<int> entitiesGroup = null)
>>>>>>> parent of 766d80f ([src] add PaymentHandler, update client and payment requests, add last range querying)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        base.Functionality = functionality;
        base.RangeStart = rangeStart;
        base.RangeWidth = rangeWidth;
        base.EntityId = entityId;
        base.EntitiesGroup = entitiesGroup;
    }
}