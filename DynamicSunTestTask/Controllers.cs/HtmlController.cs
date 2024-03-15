using DynamicSunTestTask.ActionResult;
using Microsoft.AspNetCore.Mvc;

namespace DynamicSunTestTask.Controllers.cs
{
    [Route("/api/{controller}")]
    public class HtmlController : ControllerBase
    {
        private readonly Func<string, HtmlResult> _htmlResult;

        public HtmlController(Func<string, HtmlResult> htmlResult)
        {
            _htmlResult = htmlResult;
        }

        [HttpGet]
        [Route("mainPage")]
        public IActionResult WriteColumns()
        {
            return _htmlResult(@"./wwwroot/html/MainPage.html");
        }
    }
}