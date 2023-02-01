using Microsoft.AspNetCore.Mvc;

namespace Teste___Webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestingController : ControllerBase
{
    private readonly ILogger<TestingController> _logger;

    public TestingController(ILogger<TestingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Test")]
    public string GetTestMessage()
    {
      return "This is a test";
    }
}
