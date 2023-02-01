using Microsoft.AspNetCore.Mvc;

namespace Teste___Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Test")]
    public string GetTestMessage()
    {
      return "This is a test";
    }
}
