using Business.Abstract;
using Business.Requests.Rentals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _rentalService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateRentalRequest request)
        {
            var result = _rentalService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateRentalRequest request)
        {
            var result = _rentalService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteRentalRequest request)
        {
            var result = _rentalService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
