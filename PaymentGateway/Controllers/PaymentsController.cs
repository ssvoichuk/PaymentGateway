using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
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
        public PaymentsController(ILogger<PaymentsController> logger,
            IUserInfoStorage userInfoStorage)
        {
            _logger = logger;
            _userInfoStorage = userInfoStorage;
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
        public void Post([FromBody] PaymentRequest paymentRequest)
        {
            var payment = new Payment
            {
                Id = paymentRequest.Id,
                CardNumber = paymentRequest.CardNumber,
                Status = "processing"
            };

            _userInfoStorage.SaveOrUpdatePayment(payment);
        }
    }
}
