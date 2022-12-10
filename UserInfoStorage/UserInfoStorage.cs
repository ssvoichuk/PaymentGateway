using PaymentGateway.Models;
using System.Security.Cryptography.X509Certificates;

namespace UserInfoStorage
{
    public class UserInfoStorage : IUserInfoStorage
    {
        private static List<Payment> payments = new List<Payment> {
                new Payment {
                    Id = "0f8fad5b-d9cb-469f-a165-70867728950e",
                    CardNumber = "12345600001234",
                    Status = "Success"
                },
                new Payment {
                    Id = "7c9e6679-7425-40de-944b-e07fc1f90ae7",
                    CardNumber = "65432100004321",
                    Status = "Failure"
                }
            };
        public List<Payment> GetPayments()
        {
            return payments.Select(s=> new Payment { 
                Id = s.Id,
                CardNumber = SecureCardNumber(s.CardNumber),
                Status= s.Status,
            }).ToList();
        }
        public Payment GetPaymentById(string id)
        {
            return payments.SingleOrDefault(x => x.Id == id);
        }
        public void SaveOrUpdatePayment(Payment payment)
        {
            var _payment = payments.SingleOrDefault(_ => _.Id == payment.Id);

            if (_payment == null)
            {
                payment.Id = Guid.NewGuid().ToString();
                payments.Add(payment);
            }
            else
            {
                _payment.Status = payment.Status;
            }
        }

        private string SecureCardNumber(string cardNumber)
        {
            return cardNumber.Remove(6, 4).Insert(6, "****");
        }
    }
}