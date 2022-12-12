namespace PaymentGateway.Models
{
    public class Payment
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string CardNumber { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
        public string SecureToken { get; set; }
    }
}
