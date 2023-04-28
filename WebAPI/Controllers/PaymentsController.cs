using Core.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public void Add(Payment payment)
        {
            _service.Add(payment);
        }

        [HttpPut]
        public void Update(Payment payment)
        {
            _service.Update(payment);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
