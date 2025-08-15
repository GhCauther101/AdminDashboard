using AdminDashboard.API.Reuqests.Payment;
using AdminDashboard.Entity.Event.Querying;
using AdminDashboard.Entity.Models;
using AdminDashboard.Repository.Managers;
using MediatR;

namespace AdminDashboard.API.Handlers;

public class ServiceHandler :
      IRequestHandler<ServiceGetSnap, SnapQueryResult>
{
    private readonly IMediator _mediator;

    private readonly RepositoryManager _repoManager;

    public ServiceHandler(IMediator mediator, RepositoryManager repositoryManager)
    {
        _mediator = mediator;
        _repoManager = repositoryManager;
    }

    public Task<SnapQueryResult> Handle(ServiceGetSnap request, CancellationToken cancellationToken)
    {
        var clientsCount = _repoManager.ClientRepository.ClientsCount;
        var paymentsCount = _repoManager.PaymentRepository.PaymentsCount;
        var paymentsBill = _repoManager.PaymentRepository.TotalBill;
        var averageBill = paymentsBill / paymentsCount;

        var snap = new Snap {ClientCount = clientsCount, PaymentCount = paymentsCount, TotalBill = paymentsBill, AverageBillStage = averageBill };
        return Task.FromResult(new SnapQueryResult(true, snap));
    }
}