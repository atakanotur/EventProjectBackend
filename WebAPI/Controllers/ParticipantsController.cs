using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        IParticipantService _participantService;
        public ParticipantsController(IParticipantService participantService)
        {
            _participantService = participantService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _participantService.GetAll();
            if(result.Success) return Ok(result.Data);
            return BadRequest(result.Message);
        }

        [HttpGet("getbyeventid")]
        public IActionResult GetByEventId(int eventId)
        {
            var result = _participantService.GetByMyEventId(eventId);
            if(result.Success) return Ok(result.Data.ToList());
            return BadRequest(result.Message);
        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _participantService.GetByUserId(userId);
            if(result.Success) return Ok(result.Data.ToList());
            return BadRequest(result.Message);
        }

        [HttpGet("getattendemyeventsids")]
        public IActionResult GetAttendedMyEventsIds(int userId)
        {
            var result = _participantService.GetAttendedMyEventIds(userId);
            if (result.Success) return Ok(result.Data.ToList());
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(Participant participant)
        {
            var result = _participantService.Add(participant);
            if(result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Participant participant)
        {
            var result = _participantService.Delete(participant);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Participant participant)
        {
            var result = _participantService.Update(participant);
            if (result.Success) return Ok(result.Message);
            return BadRequest(result.Message);
        }

    }
}
