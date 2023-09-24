using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AnimalController : ControllerBase
{    private readonly ILogger<AnimalController> _logger;

    public AnimalController(ILogger<AnimalController> logger)
    {
        _logger = logger;
    }


}