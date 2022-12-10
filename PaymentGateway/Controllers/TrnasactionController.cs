using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Models;
using System.Transactions;
using UserInfoStorage;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrnasactionController : ControllerBase
    {
        private readonly IUserInfoStorage _userInfoStorage;
        public TrnasactionController(IUserInfoStorage userInfoStorage)
        {
            _userInfoStorage = userInfoStorage;
        }

        // GET api/<TrnasactionController>/5
        [HttpGet("{id}, {status}")]
        public void Get(string id, string status)
        {
            var payment = new Payment
            {
                Id = id,
                Status = status
            };
            _userInfoStorage.SaveOrUpdatePayment(payment);
        }
    }
}
