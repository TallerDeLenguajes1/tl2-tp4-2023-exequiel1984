using Microsoft.AspNetCore.Mvc;
using Practico1;

namespace Practico1.Controllers;

[ApiController]
[Route("[controller]")]
public class CadeteriaController : ControllerBase
{
    /*CADETERIA*/
    private Cadeteria cadeteria;
    private readonly ILogger<CadeteriaController> _logger;

    public CadeteriaController(ILogger<CadeteriaController> logger)
    {
        _logger = logger;
        AccesoADatos CargarDatosCSV = new AccesoCSV();
        cadeteria = CargarDatosCSV.CargarDatosCadeteria();
        //cadeteria = new Cadeteria("Pedidos Ya", "38155666");
    }

    /*CADETES*/
    /* private static AccesoADatos CargarDatosCSV = new AccesoCSV()
    {
        Cadeteria NuevaCadeteria = CargarDatosCSV.CargarDatosCadeteria();
    } */

    /* private static List<Cadete> cadetes = new List<Cadete>
    {
    } */

    [HttpGet]
    public ActionResult<string> GetNombreCadeteria()
    {
        return cadeteria.Nombre;
    }

    /* [HttpGet(Name = "GetCadetes")]
    public ActionResult<IEnumerable<Cadete>> GetAll()
    {
        return Ok()
    } */
}