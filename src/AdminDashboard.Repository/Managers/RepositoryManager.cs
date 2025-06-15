using AdminDashboard.Contracts.Repository;
using AdminDashboard.Repository.Context;
using AdminDashboard.Repository.Domains;

namespace AdminDashboard.Repository.Managers;

public class RepositoryManager : IRepositoryManager
{
    private IdentityContext _identityContext;
    private RepositoryContext _repositoryContext;
    private EventContext _eventContext;

    private IClientRepository _clientRepository;
    private IPaymentRepository _paymentRepository;
    private IEventRepository _eventRepository;

    public RepositoryManager(DbContextBus dbContextBus)
    {
        _identityContext = dbContextBus.IdentityContextInstance;
        _repositoryContext = dbContextBus.RepositoryContextInstance;
        _eventContext = dbContextBus.EventContextInstance;
    }

    public IClientRepository ClientRepository
    {
        get
        {
            if (_clientRepository == null)
                _clientRepository = new ClientRepository(_identityContext);

            return _clientRepository;
        }
    }

    public IPaymentRepository PaymentRepository
    {
        get
        {
            if (_paymentRepository == null)
                _paymentRepository = new PaymentRepository(_repositoryContext);

            return _paymentRepository;
        }
    }

    public IEventRepository EventRepository
    {
        get
        {
            if (_eventRepository == null)
                _eventRepository = new EventRepository(_eventContext);

            return _eventRepository;
        }
    }

    public async Task SaveChanges()
    {
        await _identityContext.SaveChangesAsync();
        await _repositoryContext.SaveChangesAsync();
    }
}