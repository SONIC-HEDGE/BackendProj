using Microsoft.AspNetCore.Mvc;
using System;

namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet("/hello")]
        public IActionResult Hello()
        {
            return Content("Hello World!");
        }

        [HttpPut("/put")]
        public IActionResult SetVariable([FromQuery] string parameter)
        {
            Console.WriteLine(parameter);
            return Ok($"Received: {parameter}");
        }
        
        [HttpGet("/status")]
        public IActionResult Status()
        {
            return Ok("API is running smoothly!");
        }

    }
}