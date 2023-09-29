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
        cadeteria = Cadeteria.GetInstance();
    }

    


    [HttpGet]
    public ActionResult<Cadeteria> GetCadeteria()
    {
        return Ok(cadeteria);
    }

    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes(){
        var cadetes = cadeteria.GetCadetes();
        return Ok(cadetes);
    }

    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = cadeteria.GetPedidos();
        return Ok(pedidos);
    }

    [HttpGet]
    [Route("Informe")]
    public ActionResult<Informe>GetInforme()
    {
        var informe = cadeteria.GetInforme();
        return Ok(informe);
    } 

    [HttpPost("AddPedido")]
    public ActionResult<Pedido> AddPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.AddPedido(pedido);
        return Ok(nuevoPedido);
    }

    /* [HttpPost("InicializarDatos")]
    public ActionResult<string> InicializarDatos(int i)
    {
        cadeteria.CargaDatosIniciales(i);
        return Ok("Carga Correcta");
    } */

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var asigPedido = cadeteria.AsignarPedido(idPedido, idCadete);
        return Ok(asigPedido);
    }

    [HttpPut("CambiarEstadoPedido")]
    public ActionResult<Pedido> CambiarEstadoPedido(int idPedido, Estados nuevoEstado)
    {
        var camEstadoPedido = cadeteria.CambiarEstadoPedido(idPedido, nuevoEstado);
        return Ok(camEstadoPedido);
    }

    [HttpPut("CambiarCadetePedido")]
    public ActionResult<Pedido> CambiarCadetePedido(int idPedido, int idNuevoCadete)
    {
        var camCadetePedido = cadeteria.CambiarCadetePedido(idPedido, idNuevoCadete);
        return Ok(camCadetePedido);
    }
}