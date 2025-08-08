using AdminDashboard.Entity.Models;

namespace AdminDashboard.Repository.Helpers;

public static class RepositoryHelper
{
    public static IQueryable<Payment> SelectPayments(this IQueryable<Payment> payments)
    {
        return payments.Select(p => new Payment
        {
            PaymentId = p.PaymentId,
            Bill = p.Bill,
            ProcessTime = p.ProcessTime,
            SourceClient = new Client { Id = p.SourceClient.Id, UserName = p.SourceClient.UserName },
            DestinationClient = new Client { Id = p.DestinationClient.Id, UserName = p.DestinationClient.UserName }
        });
    }

    public static decimal SumPaymentsCollection(this IEnumerable<Payment> payments)
    {
        return payments.Select(p => p.Bill).ToArray().Sum();
    }

    public static decimal SumPayments(this Client client)
    {
        return (client.SentPayments.SumPaymentsCollection() + client.RecievedPayments.SumPaymentsCollection());
    }
}