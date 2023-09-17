using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EstadoAnimalController : ControllerBase
{    private readonly ILogger<EstadoAnimalController> _logger;

    public ClienteController(ILogger<EstadoAnimalController> logger)
    {
        _logger = logger;
    }


}