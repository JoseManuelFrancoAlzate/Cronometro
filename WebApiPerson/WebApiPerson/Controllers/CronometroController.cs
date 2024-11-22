using Microsoft.AspNetCore.Mvc;
using WebApiPerson.Models;
using WebApiPerson.Services;

namespace WebApiPerson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CronometrosController : ControllerBase
    {
        private readonly CronometroService _cronometroService;

        
        public CronometrosController(CronometroService cronometroService)
        {
            _cronometroService = cronometroService;
        }

        // GET: api/Cronometros
        
        [HttpGet] 
        public ActionResult<Cronometro> GetCronometro()
        {
            var estado = _cronometroService.ObtenerEstado();
            return Ok(estado);
        }

        // POST: api/Cronometros/start
       
        [HttpPost("start")]
        public IActionResult StartCronometro()
        {
            _cronometroService.Iniciar();
            return Ok("Cronómetro iniciado.");
        }

        // POST: api/Cronometros/pause
        
        [HttpPost("pause")]
        public IActionResult PauseCronometro()
        {
            _cronometroService.Pausar();
            return Ok("Cronómetro pausado.");
        }

        // POST: api/Cronometros/reset
      
        [HttpPost("reset")]
        public IActionResult ResetCronometro()
        {
            _cronometroService.Reiniciar();
            return Ok("Cronómetro reiniciado.");
        }
    }
}
