using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace WebApiPerson.Hubs
{
    public class CronometroHub : Hub
    {
        // Método que los clientes pueden llamar
        public async Task EnviarTiempo(string tiempo)
        {
            await Clients.All.SendAsync("RecibirTiempo", tiempo);
        }
    }
}
