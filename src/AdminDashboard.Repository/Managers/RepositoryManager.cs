using AdminDashboard.Contracts.Repository;
using AdminDashboard.Repository.Context;
using AdminDashboard.Repository.Domains;

namespace AdminDashboard.Repository.Managers;

public class RepositoryManager : IRepositoryManager
{
    private DbContextBus _dbContextBus;

    private IClientRepository _clientRepository;
    private IPaymentRepository _paymentRepository;
    private IEventRepository _eventRepository;

    public RepositoryManager(DbContextBus dbContextBus)
    {
        _dbContextBus = dbContextBus;
    }

    public IClientRepository ClientRepository
    {
        get
        {
            if (_clientRepository == null)
                _clientRepository = new ClientRepository(_dbContextBus);

            return _clientRepository;
        }
    }

    public IPaymentRepository PaymentRepository
    {
        get
        {
            if (_paymentRepository == null)
                _paymentRepository = new PaymentRepository(_dbContextBus);

            return _paymentRepository;
        }
    }

    public IEventRepository EventRepository
    {
        get
        {
            if (_eventRepository == null)
                _eventRepository = new EventRepository(_dbContextBus);

            return _eventRepository;
        }
    }

    public async Task SaveChanges()
    {
        await _dbContextBus.IdentityContextInstance.SaveChangesAsync();
        await _dbContextBus.RepositoryContextInstance.SaveChangesAsync();
    }
}