using PaymentGateway.Models;

namespace UserInfoStorage
{
    public interface IUserInfoStorage
    {
        Payment GetPaymentById(string id);
        List<Payment> GetPayments();
        void SavePayment(Payment payment);
        void UpdatePayment(Payment payment, string token);
    }
}