using Microsoft.AspNetCore.Mvc;

namespace GatewayService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonitorController : ControllerBase
    {
        [HttpHead("/shallow")]
        public IActionResult Shallow()
        {
            return Ok();
        }
    }
}
