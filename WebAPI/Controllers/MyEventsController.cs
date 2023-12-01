using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyEventsController : ControllerBase
    {
        IMyEventService _myEventService;

        public MyEventsController(IMyEventService myEventService)
        {
            _myEventService = myEventService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _myEventService.GetAll();
            if(result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbymyeventid")]
        public IActionResult GetByMyEventId(int myEventId)
        {
            var result = _myEventService.GetById(myEventId);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _myEventService.GetById(userId);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getactives")]
        public IActionResult GetActives(int userId)
        {
            var result = _myEventService.GetActives(userId);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getattendedmyeventsbyuserid")]
        public IActionResult GetAttendedMyEventsByUserId(int userId)
        {
            var result = _myEventService.GetAttendedMyEventsByUserId(userId);
            if (result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(MyEvent myEvent)
        {
            var result = _myEventService.Add(myEvent);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(MyEvent myEvent)
        {
            var result = _myEventService.Delete(myEvent);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(MyEvent myEvent)
        {
            var result = _myEventService.Update(myEvent);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("joinmyevent")]
        public IActionResult JoinMyEvent(Participant participant)
        {
            var result = _myEventService.JoinMyEvent(participant);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("leavemyevent")]
        public IActionResult LeaveMyEvent(Participant participant)
        {
            var result = _myEventService.LeaveMyEvent(participant);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
