using Business.Abstract;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Business.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("GetList")]
        public PaginateListCarResponse GetList([FromQuery] PageRequest request)
        {
            return _carService.GetList(request);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAll();
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("GetByBrandId")]
        public IActionResult GetByBrandId(int brandId) 
        {
            var result = _carService.GetCarsByBrandId(brandId);
            return StatusCode(result.Success ? 200 : 400,result);
        }

        [HttpGet("GetByColorId")]
        public IActionResult GetByColorId(int colorId) 
        { 
            var result = _carService.GetCarsByColorId(colorId);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _carService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateCarRequest request)
        {
            var result = _carService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateCarRequest request)
        {
            var result = _carService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteCarRequest request)
        {
            var result = _carService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
