using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicoController : ControllerBase
{    private readonly ILogger<MedicoController> _logger;

    public ClienteController(ILogger<MedicoController> logger)
    {
        _logger = logger;
    }


}