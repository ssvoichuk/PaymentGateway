namespace PaymentGateway.Models
{
    public class PaymentRequest
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
    }
}
