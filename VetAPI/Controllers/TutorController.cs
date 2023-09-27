using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TutorController : ControllerBase
{    private readonly ILogger<TutorController> _logger;

    public TutorController(ILogger<TutorController> logger)
    {
        _logger = logger;
    }


}