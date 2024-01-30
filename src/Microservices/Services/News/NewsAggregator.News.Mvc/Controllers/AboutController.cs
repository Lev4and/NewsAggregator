using Microsoft.AspNetCore.Mvc;

namespace NewsAggregator.News.Mvc.Controllers
{
    [Route("about")]
    public class AboutController : Controller
    {
        public AboutController()
        {
            
        }

        [HttpGet("", Name = "About")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
