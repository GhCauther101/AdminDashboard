using AdminDashboard.Contracts.Repository;
using AdminDashboard.Entity.Event.Querying.Common;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdminDashboard.Repository.Domains;

public class RepositoryBase<T> where T : class
{
    private readonly DbContextBus _dbContextBus;

    public RepositoryBase(IDbContextBus dbContextBus)
    {
        _dbContextBus = dbContextBus as DbContextBus;
    }

    public DbContext GetDbContext()
    {
        return _dbContextBus.IdentityContextInstance;
    }

    protected QueryPager GetRepositoryPager()
    {
        var context = GetDbContext();
        var totalCount = context.Set<T>().Count();
        var width = DbContextConfig.PagerWidth;

        var process = (double)(totalCount / width);
        var pageCount = (int)Math.Ceiling(process);
        
        return new QueryPager( totalCount, pageCount );
    }

    protected IQueryable<T> FindAll(bool trackChanges)
    {
        var repository = GetDbContext();
        return !trackChanges ? repository.Set<T>().AsNoTracking() : repository.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        var repository = GetDbContext();
        return !trackChanges ? repository.Set<T>().Where(expression).AsNoTracking() : repository.Set<T>().Where(expression);
    }

    public void Create(T entity)
    {
        var repository = GetDbContext();
        repository.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        var repository = GetDbContext();
        repository.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        var repository = GetDbContext();
        repository.Set<T>().Remove(entity);
    }
}