using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class LogradouroController : ControllerBase
{    private readonly ILogger<LogradouroController> _logger;

    public LogradouroController(ILogger<LogradouroController> logger)
    {
        _logger = logger;
    }


}
