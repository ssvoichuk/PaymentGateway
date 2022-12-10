using PaymentGateway.Models;

namespace UserInfoStorage
{
    public interface IUserInfoStorage
    {
        Payment GetPaymentById(string id);
        List<Payment> GetPayments();
        void SaveOrUpdatePayment(Payment payment);
    }
}