using Business.Abstract;
using Business.Requests.CarImages;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{getByImageId}")]
        public IActionResult GetById(int imageId)
        {
            var result = _carImageService.GetByImageId(imageId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file)
        {
            var result = _carImageService.Add(file);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] CarImage image)
        {
            var result = _carImageService.Update(file, image);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteCarImageRequest request)
        {
            var result = _carImageService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
