using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MVC.Controllers
{
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;

        public MyController(ILogger<MyController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetHelloWordWithString([FromQuery] string from)
        {
            var model = $"Hello word from {from}";
            return View("HelloWorld", model);
        }
    }
}