using AdminDashboard.Entity.Models;

namespace AdminDashboard.Entity.Event.Querying.Common;

public class QueryPagerResult : QueryResult<QueryPager>
{
    public QueryPagerResult()
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
    }

    public QueryPagerResult(
        bool isSuccess,
        QueryPager pager = null,
        Exception exception = null)
    {
        base.Id = Guid.NewGuid();
        base.TriggerTime = DateTime.Now;
        base.TriggerClusterId = Guid.NewGuid();
        IsSuccess = isSuccess;
        Entity = pager;
        Exception = exception;
    }
}