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
        cadeteria = Cadeteria.GetCadeteria();
    }

    [HttpGet]
    public ActionResult<string> GetNombreCadeteria()
    {
        return Ok(cadeteria.Nombre);
    }

    [HttpGet]
    [Route("Cadetes")]
    public ActionResult<IEnumerable<Cadete>> GetCadetes(){
        var cadetes = cadeteria.GetCadetes();
        return Ok(cadetes);
    }

    [HttpPost("AddPedido")]
    public ActionResult<Pedido> AddPedido(Pedido pedido)
    {
        var nuevoPedido = cadeteria.AddPedido(pedido);
        return Ok(nuevoPedido);
    }

    [HttpGet]
    [Route("Pedidos")]
    public ActionResult<IEnumerable<Pedido>> GetPedidos()
    {
        var pedidos = cadeteria.GetPedidos();
        return Ok(pedidos);
    }

    [HttpPut("AsignarPedido")]
    public ActionResult<Pedido> AsignarPedido(int idPedido, int idCadete)
    {
        var asigPedido = cadeteria.AsignarPedido(idPedido, idCadete);
        return Ok(asigPedido);
    }
}