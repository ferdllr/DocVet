using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MedicamentoController : ControllerBase
{    private readonly ILogger<MedicamentoController> _logger;

    public MedicamentoController(ILogger<MedicamentoController> logger)
    {
        _logger = logger;
    }


}