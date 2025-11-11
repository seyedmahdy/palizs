using Microsoft.AspNetCore.Mvc;
using static BlazorApp1.Components.Pages.Commodity;

namespace BlazorApp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class HiController : ControllerBase
    {

        
        [HttpGet("1")]
        public IActionResult GetAll()
        {
            return Ok("hi");
        }
        [HttpGet("2")]
        public IActionResult GetAll2()
        {
            return Ok("hi");
        }
    }
}
