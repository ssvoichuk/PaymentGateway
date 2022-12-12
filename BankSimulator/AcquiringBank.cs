using PaymentGateway.Models;
using System;
using System.Net;

namespace BankSimulator
{

    public class AcquiringBank : IAcquiringBank
    {
        static readonly HttpClient client = new HttpClient();
        public async Task ProceedPayment(Payment payment, bool success)
        {
            //simulate request to third API
            await Task.Delay(1000);
            if (success)
            {
                await SimulateSuccessUrl(payment.SuccessUrl);
            }
            else
            {
                await SimulateFailureUrl(payment.FailureUrl);
            }

        }
        public async Task SimulateSuccessUrl(string url)
        {
            await client.GetStringAsync(url);
        }

        public async Task SimulateFailureUrl(string url)
        {
            await client.GetStringAsync(url);
        }
    }
}