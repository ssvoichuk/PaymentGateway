using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Models
{
    public class PaymentRequest
    {
        public string Id { get; set; }

        [Required]
        public string ShopperName { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Enter 16 numbers")]
        public string CardNumber { get; set; }
        [Required]
        public string ExpiryDate { get; set; }
        [Required]
        public string CVV { get; set; }
        [Required]
        public string MerchantId { get; set; }
        public string SuccessUrl { get; set; }
        public string FailureUrl { get; set; }
    }
}
