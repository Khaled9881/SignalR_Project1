using Microsoft.AspNetCore.SignalR;

namespace SignalR_Project1.Hubs
{
    public class ChatHub : Hub
    {
        public void sendMessage(string name, string message)
        {
            // receive messag and store it in DB


            // Broadcating message to clients


            Clients.All.SendAsync("newMessage", name, message);
        }

    }
}
