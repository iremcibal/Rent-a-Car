using Business.Abstract;
using Business.Requests.Brands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _brandService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _brandService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateBrandRequest request)
        {
            var result = _brandService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateBrandRequest request)
        {
            var result = _brandService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteBrandRequest request)
        {
            var result = _brandService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
