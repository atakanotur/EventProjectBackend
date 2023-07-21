using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyEventTypesController : ControllerBase
    {
        IMyEventTypeService _myEventTypeService;
        public MyEventTypesController(IMyEventTypeService myEventTypeService)
        {
            _myEventTypeService = myEventTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _myEventTypeService.GetAll();
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(MyEventType myEventType)
        {
            var result = _myEventTypeService.Add(myEventType);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(MyEventType myEventType)
        {
            var result = _myEventTypeService.Delete(myEventType);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(MyEventType myEventType)
        {
            var result = _myEventTypeService.Update(myEventType);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
