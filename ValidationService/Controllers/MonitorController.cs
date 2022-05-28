using Microsoft.AspNetCore.Mvc;

namespace ValidationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : Controller
    {
        [HttpHead("/shallow")]
        public IActionResult Shallow()
        {
            return Ok();
        }
    }
}
