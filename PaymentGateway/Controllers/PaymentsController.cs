using BankSimulator;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
using System.Net;
using UserInfoStorage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {

        private readonly ILogger<PaymentsController> _logger;
        private readonly IUserInfoStorage _userInfoStorage;
        private readonly IAcquiringBank _acquiringBank;
        public PaymentsController(ILogger<PaymentsController> logger,
            IUserInfoStorage userInfoStorage,
            IAcquiringBank acquiringBank)
        {
            _logger = logger;
            _userInfoStorage = userInfoStorage;
            _acquiringBank = acquiringBank;
        }

        // GET: api/<PaymentsController>
        [HttpGet]
        public IEnumerable<Payment> Get()
        {
            return _userInfoStorage.GetPayments();
        }

        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        public Payment Get(string id)
        {
            return _userInfoStorage.GetPaymentById(id);
        }

        // POST api/<PaymentsController>
        [HttpPost]
        public async Task<ActionResult<PaymentResponse>> Post([FromBody] PaymentRequest paymentRequest)
        {
            var response = new PaymentResponse();

            var payment = new Payment
            {
                Id = Guid.NewGuid().ToString(),
                SecureToken = Guid.NewGuid().ToString(),
                CardNumber = paymentRequest.CardNumber,
                Status = "processing"
            };

            payment.SuccessUrl = GetSuccessUrl(payment.Id, payment.SecureToken);
            payment.SuccessUrl = GetFailureUrl(payment.Id, payment.SecureToken);

            try
            {
                _userInfoStorage.SavePayment(payment);
                await _acquiringBank.ProceedPayment(payment, true);

                response.Id = paymentRequest.Id;
                response.Status = "processing";
                response.Message = "payment has been created";
            }
            catch (Exception ex)
            {
                response.Status = "failed";
                response.Message = ex.Message;
            }

            return response;
        }
        private string GetSuccessUrl(string id, string token)
        {
            return string.Format("https://{0}/api/{1}/{2}/{3}/{4}",
                Request.Host.ToString(),
                "transaction", "success", id, token);
        }

        private string GetFailureUrl(string id, string token)
        {
            return string.Format("https://{0}/api/{1}/{2}/{3}/{4}",
                Request.Host.ToString(),
                "transaction", "failure", id, token);
        }

    }
}
