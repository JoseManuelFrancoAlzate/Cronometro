using Microsoft.AspNetCore.Mvc;
using WebApiPerson.Models;
using WebApiPerson.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporizadorController : ControllerBase
    {
        private readonly TemporizadorService _temporizadorService;
        public TemporizadorController(TemporizadorService temporizadorService)
        {
            _temporizadorService = temporizadorService;
        }

        // GET: api/<TemporizadorController>
        [HttpGet]
        public ActionResult<Temporizador> GetTemporizador()
        {
            var estado = _temporizadorService.ObtenerEstado();
            return Ok(estado);
        }
        [HttpPost("start")]
        public IActionResult StartTemporizador(int minutes)
        {
            _temporizadorService.Iniciar(minutes);
            return Ok($"Temporizador Iniciado, cantidad de minutos: {minutes}");
        }
        [HttpPost("Pause")]
        public IActionResult PauseTemporizador()
        {
            _temporizadorService.Pausar();
            return Ok("Pausado");
        }

        [HttpPost("Reset")]
        public IActionResult ResetTemporizador()
        {
            _temporizadorService.Reiniciar();
            return Ok("Reiniciado");
        }

    }
}
