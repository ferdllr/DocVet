using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedimentosController : ControllerBase
{    private readonly ILogger<ProcedimentosController> _logger;

    public ClienteController(ILogger<ProcedimentosController> logger)
    {
        _logger = logger;
    }


}