using Microsoft.AspNetCore.Mvc;

namespace NetcoreAccountsService.Controllers
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
