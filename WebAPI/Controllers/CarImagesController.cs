using Business.Abstract;
using Business.Requests.CarImages;
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

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _carImageService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateCarImageRequest request)
        {
            var result = _carImageService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateCarImageRequest request)
        {
            var result = _carImageService.Update(request);
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
