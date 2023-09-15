using Microsoft.AspNetCore.Mvc;
using Practico1;

namespace Practico1.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        cadeteria = new Cadeteria("Pedidos Ya", "38155666");


    }

    [HttpGet]
    public ActionResult<string> GetNombreCadeteria()
    {
        return cadeteria.Nombre;
    }
}