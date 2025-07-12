using Microsoft.AspNetCore.Mvc;

namespace ezametric_backend;

[ApiController]
[Route("api/[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        return Ok("Hello World from C# API!");
    }
}