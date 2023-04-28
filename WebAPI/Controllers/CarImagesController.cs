using Core.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/cars/images")]
    public class CarImagesController : Controller
    {
        private readonly ICarImageService _service;

        public CarImagesController(ICarImageService service)
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
        public void Add([FromForm] CarImage carImage, [FromForm(Name = "image")] IFormFile formFile)
        {
            _service.Add(carImage, formFile);
        }

        [HttpPut]
        public void Update([FromForm] CarImage carImage, [FromForm(Name = "image")] IFormFile formFile)
        {
            _service.Update(carImage, formFile);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
