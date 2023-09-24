using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProcedimentoController : ControllerBase
{    private readonly ILogger<ProcedimentoController> _logger;

    public ProcedimentoController(ILogger<ProcedimentoController> logger)
    {
        _logger = logger;
    }


}