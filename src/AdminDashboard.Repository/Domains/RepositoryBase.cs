using AdminDashboard.Contracts.Repository;
using AdminDashboard.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AdminDashboard.Repository.Domains;

public class RepositoryBase<T> where T : class
{
    private readonly DbContextBus _dbContextBus;

    public RepositoryBase(IDbContextBus dbContextBus)
    {
        _dbContextBus = dbContextBus as DbContextBus;
    }

    private DbContext DetectDomainDbContext(DbContextDomain domain)
    {
        return domain switch
        {
            DbContextDomain.IDENTITY => (DbContext)_dbContextBus.IdentityContextInstance,
            DbContextDomain.REPOSITORY => (DbContext)_dbContextBus.RepositoryContextInstance,
            DbContextDomain.EVENT => (DbContext)_dbContextBus.EventContextInstance
        };
    }

    protected IQueryable<T> FindAll(DbContextDomain domain, bool trackChanges)
    {
        var repository = DetectDomainDbContext(domain);
        return !trackChanges ? repository.Set<T>().AsNoTracking() : repository.Set<T>();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, DbContextDomain domain, bool trackChanges)
    {
        var repository = DetectDomainDbContext(domain);
        return !trackChanges ? repository.Set<T>().Where(expression).AsNoTracking() : repository.Set<T>().Where(expression);
    }

    public void Create(T entity, DbContextDomain domain)
    {
        var repository = DetectDomainDbContext(domain);
        repository.Set<T>().Add(entity);
    }

    public void Update(T entity, DbContextDomain domain)
    {
        var repository = DetectDomainDbContext(domain);
        repository.Set<T>().Update(entity);
    }

    public void Delete(T entity, DbContextDomain domain)
    {
        var repository = DetectDomainDbContext(domain);
        repository.Set<T>().Remove(entity);
    }
}