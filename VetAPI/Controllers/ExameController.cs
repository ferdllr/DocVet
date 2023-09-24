using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ExameController : ControllerBase
{    private readonly ILogger<ExameController> _logger;

    public ExameController(ILogger<ExameController> logger)
    {
        _logger = logger;
    }


}