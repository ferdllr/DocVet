using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProntuarioController : ControllerBase
{    private readonly ILogger<ProntuarioController> _logger;

    public ProntuarioController(ILogger<ProntuarioController> logger)
    {
        _logger = logger;
    }


}