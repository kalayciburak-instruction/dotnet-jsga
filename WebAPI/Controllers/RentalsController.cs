using Core.Abstract;
using Entities;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/rentals")]
    public class RentalsController : Controller
    {
        private readonly IRentalService _service;

        public RentalsController(IRentalService service)
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
        public void Add(RentalDto rentalDto)
        {
            _service.Add(rentalDto);
        }

        [HttpPut]
        public void Update(Rental rental)
        {
            _service.Update(rental);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
