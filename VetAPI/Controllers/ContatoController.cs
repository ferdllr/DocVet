using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ContatoController : ControllerBase
{    private readonly ILogger<ContatoController> _logger;

    public ContatoController(ILogger<ContatoController> logger)
    {
        _logger = logger;
    }


}