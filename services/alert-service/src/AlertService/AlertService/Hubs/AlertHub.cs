using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using AlertService.Models;

namespace AlertService.Hubs
{
    public class AlertHub : Hub
    {
        // Optional: Wenn ein Client sich verbindet
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            // Du könntest hier z.B. eine Nachricht senden:
            // await Clients.Caller.SendAsync("ReceiveMessage", "Willkommen im AlertHub!");
        }

        // Optional: Wenn ein Client die Verbindung trennt
        public override async Task OnDisconnectedAsync(System.Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        // Server-Methode, um eine Alert-Nachricht an alle Clients zu pushen
        public async Task SendAlert(Alert alert)
        {
            // Sendet die Alert-Instanz an alle verbundenen Clients
            await Clients.All.SendAsync("ReceiveAlert", alert);
        }
    }
}
