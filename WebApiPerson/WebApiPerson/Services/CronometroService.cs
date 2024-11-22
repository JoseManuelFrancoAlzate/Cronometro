using WebApiPerson.Models;
using Microsoft.AspNetCore.SignalR;
using WebApiPerson.Hubs;
using System.Threading.Tasks;

namespace WebApiPerson.Services
{
    public class CronometroService
    {
        private readonly IHubContext<CronometroHub> _hubContext;
        private Cronometro _cronometro = new Cronometro();

        public CronometroService(IHubContext<CronometroHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Cronometro ObtenerEstado()
        {
          
            if (_cronometro.EstaCorriendo && _cronometro.Inicio.HasValue)
            {
                _cronometro.TiempoTranscurrido += DateTime.Now - _cronometro.Inicio.Value;
                _cronometro.Inicio = DateTime.Now;
            }

          
            _hubContext.Clients.All.SendAsync("RecibirTiempo", _cronometro.TiempoTranscurrido.ToString());

            return _cronometro;
        }

        public void Iniciar()
        {
            if (!_cronometro.EstaCorriendo)
            {
                _cronometro.Inicio = DateTime.Now;
                _cronometro.EstaCorriendo = true; 
            }
        }

        public void Pausar()
        {
            if (_cronometro.EstaCorriendo && _cronometro.Inicio.HasValue)
            {
                _cronometro.TiempoTranscurrido += DateTime.Now - _cronometro.Inicio.Value; 
                _cronometro.EstaCorriendo = false; 
                _cronometro.Inicio = null; 
            }
        }

        public void Reiniciar()
        {
            _cronometro.TiempoTranscurrido = TimeSpan.Zero; 
            _cronometro.EstaCorriendo = false; 
            _cronometro.Inicio = null;
        }
    }
}
