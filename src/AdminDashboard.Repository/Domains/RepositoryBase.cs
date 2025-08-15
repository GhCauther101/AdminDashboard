using AdminDashboard.Contracts.Repository;
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

    public DbContext GetDbContext(DbContextDomain domain)
    {
        return domain switch
        {
            DbContextDomain.IDENTITY => (DbContext)_dbContextBus.IdentityContextInstance
        };
    }

    protected QueryPager GetRepositoryPager(DbContextDomain domain)
    {
        var context = GetDbContext(DbContextDomain.IDENTITY);
        var totalCount = context.Set<T>().Count();
        var width = DbContextConfigHelper.PagerWidth;

        var process = (double)(totalCount / width);
        var pageCount = (int)Math.Ceiling(process);
        
        return new QueryPager( totalCount, pageCount );
    }

    protected IQueryable<T> FindAll(DbContextDomain domain, bool trackChanges)
    {
        var repository = GetDbContext(domain);
        return !trackChanges ? repository.Set<T>().AsNoTracking() : repository.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, DbContextDomain domain, bool trackChanges)
    {
        var repository = GetDbContext(domain);
        return !trackChanges ? repository.Set<T>().Where(expression).AsNoTracking() : repository.Set<T>().Where(expression);
    }

    public void Create(T entity, DbContextDomain domain)
    {
        var repository = GetDbContext(domain);
        repository.Set<T>().Add(entity);
    }

    public void Update(T entity, DbContextDomain domain)
    {
        var repository = GetDbContext(domain);
        repository.Set<T>().Update(entity);
    }

    public void Delete(T entity, DbContextDomain domain)
    {
        var repository = GetDbContext(domain);
        repository.Set<T>().Remove(entity);
    }
}