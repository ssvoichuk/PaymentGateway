using PaymentGateway.Models;

namespace BankSimulator
{
    public interface IAcquiringBank
    {
        Task ProceedPayment(Payment payment, bool success);
        Task SimulateFailureUrl(string url);
        Task SimulateSuccessUrl(string url);
    }
}