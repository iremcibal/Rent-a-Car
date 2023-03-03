using Business.Abstract;
using Business.Requests.Findeks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FindeksController : ControllerBase
    {
        IFindeksService _findeksService;

        public FindeksController(IFindeksService findeksService)
        {
            _findeksService = findeksService;
        }
        [HttpGet]
        public IActionResult GetList()
        {
            var result = _findeksService.GetList();
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _findeksService.GetById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPost]
        public IActionResult Add(CreateFindeksRequest request)
        {
            var result = _findeksService.Add(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut]
        public IActionResult Update(UpdateFindeksRequest request)
        {
            var result = _findeksService.Update(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }


        [HttpDelete]
        public IActionResult Delete([FromBody] DeleteFindeksRequest request)
        {
            var result = _findeksService.Delete(request);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
