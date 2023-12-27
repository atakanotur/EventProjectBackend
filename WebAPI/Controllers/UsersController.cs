using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getbymyeventid")]
        public IActionResult GetByMyEventId(int myEventId)
        {
            var result = _userService.GetByMyEventId(myEventId);
            if (result.Success) return Ok(result.Data.ToList());
            return BadRequest(result.Message);
        }
    }
}
