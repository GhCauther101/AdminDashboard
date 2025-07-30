namespace AdminDashboard.Entity.Models;

public class QueryPager
{
    public QueryPager()
    {}

    public QueryPager(int count, int pageCount)
    {
        Count = count;
        PageCount = pageCount;
    }

    public int Count { get; set; }

    public int PageCount { get; set; }
}