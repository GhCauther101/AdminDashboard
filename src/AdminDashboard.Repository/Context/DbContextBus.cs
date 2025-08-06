using AdminDashboard.Contracts.Repository;

namespace AdminDashboard.Repository.Context;

public class DbContextBus : IDbContextBus
{
    private readonly IdentityContext _identityContext;
    private readonly RepositoryContext _repositoryContext;
    private readonly EventContext _eventContext;

    public DbContextBus(
        IdentityContext identityContext, 
        RepositoryContext repositoryContext)
    {
        _identityContext = identityContext;
        _repositoryContext = repositoryContext;
    }

    public IdentityContext IdentityContextInstance => _identityContext;

    public RepositoryContext RepositoryContextInstance => _repositoryContext;

    public EventContext EventContextInstance => _eventContext;
}
