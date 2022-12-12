using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
using System.Transactions;
using UserInfoStorage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IUserInfoStorage _userInfoStorage;
        public TransactionController(IUserInfoStorage userInfoStorage)
        {
            _userInfoStorage = userInfoStorage;
        }

        // GET api/<TrnasactionController>/5
        [HttpGet("success/{id}/{token}", Name = "Success")]
        public void Success(string id, string token)
        {
            var payment = new Payment
            {
                Id = id,
                Status = "Success"
            };
            _userInfoStorage.UpdatePayment(payment, token);
        }

        // GET api/<TrnasactionController>/5
        [HttpGet("failure/{id}/{token}", Name = "Failure")]
        public void Failure(string id, string token)
        {
            var payment = new Payment
            {
                Id = id,
                Status = "Failure"
            };
            _userInfoStorage.UpdatePayment(payment, token);
        }
    }
}
