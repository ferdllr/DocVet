using Microsoft.AspNetCore.Mvc;
using VetAPI.Models;

namespace VetAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{    private readonly ILogger<FuncionarioController> _logger;

    public FuncionarioController(ILogger<FuncionarioController> logger)
    {
        _logger = logger;
    }


}