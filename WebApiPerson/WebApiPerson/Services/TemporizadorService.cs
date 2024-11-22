using WebApiPerson.Models;
using Microsoft.AspNetCore.SignalR;
using WebApiPerson.Hubs;
using System.Threading.Tasks;
using System.Media;

namespace WebApiPerson.Services
{
    public class TemporizadorService
    {
        private readonly IHubContext<TemporizadorHub> _hubContext;
        private Temporizador _temporizador = new Temporizador();

        public TemporizadorService(IHubContext<TemporizadorHub> hubContext)
        {
            _hubContext = hubContext;
        }


        public Temporizador ObtenerEstado()
        {
            // Verifico si el temporizador ha llegado al final
            if ((_temporizador.TiempoTranscurrido >= _temporizador.Duracion) && !_temporizador.AudioReproducido)
            {
                _temporizador.EstaCorriendo = false;
                _temporizador.AudioReproducido = true; // Marcamos que el audio ya fue reproducido

                string audioPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "audio", "SonidodeGOKU.wav");

                // Verificar si el archivo existe antes de reproducirlo
                if (File.Exists(audioPath))
                {
                    using (SoundPlayer player = new SoundPlayer(audioPath))
                    {
                        player.PlaySync(); // Reproduce el audio de forma sincrónica
                    }
                }
                else
                {
                    Console.WriteLine("El archivo de audio no se encontró.");
                }
            }

            if (_temporizador.EstaCorriendo && _temporizador.Inicio.HasValue)
            {
                // Actualizamos el tiempo transcurrido
                _temporizador.TiempoTranscurrido += DateTime.Now - _temporizador.Inicio.Value;
                _temporizador.Inicio = DateTime.Now;
            }

            return _temporizador;
        }


        public void Iniciar(int minutes)
        {
            _temporizador.Duracion = TimeSpan.FromMinutes(minutes);
            Console.WriteLine("La cantidad de minutos son: ", minutes);            //Verifico que el temporizador este corriendo
            if (!_temporizador.EstaCorriendo)
            {
                //Guardo el tiempo exacto en el que comenzo el temporizador en la propiedad "Inicio":
                _temporizador.Inicio = DateTime.Now;
                //Si esta corriendo cambio el parametro a "True" para indicar que el tenporizador esta en marcha
                _temporizador.EstaCorriendo = true;
                _temporizador.AudioReproducido = false; // Restablecer el estado de audio
            }
        }

        //No permitir que cambie el valor "EstaCorriendo" se active o el metodo "Pausar" Si el valor de "Inicio" es null.
        //Tampoco puedo permitir que se pause si el tiempo transcurrido es igual o mayor a la Duracion
        //Primero debo verificar que el cronomero se alla iniciado

        public void Pausar()
        {
            if (_temporizador.Inicio.HasValue && _temporizador.TiempoTranscurrido < _temporizador.Duracion)
            {
                _temporizador.TiempoTranscurrido += DateTime.Now - _temporizador.Inicio.Value;
                _temporizador.EstaCorriendo = false;
                _temporizador.Inicio = null;
            }
        }

        public void Reiniciar()
        {
            _temporizador.TiempoTranscurrido = TimeSpan.Zero;
            _temporizador.EstaCorriendo = false;
            _temporizador.Inicio = null;
        }

    }
}

