using Microsoft.AspNetCore.SignalR;
using SignalR_Project1.Models;

namespace SignalR_Project1.Hubs
{
    public class ChatHub : Hub
    {

        private readonly ChatSignalRContext _context;

        public ChatHub(ChatSignalRContext context)
        {
            _context = context;
        }


        public void sendMessage(string name, string message)
        {
            // receive messag and store it in DB

            Chat chat = new Chat
            {
                name = name,
                message = message
            };

            _context.Chats.Add(chat);
            _context.SaveChanges();


            // Broadcating message to clients
            Clients.All.SendAsync("newMessage", name, message);


        }

        public async Task savetogroup(string name, string group)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, group);

            await Clients.OthersInGroup(group).SendAsync("welcome", name, group);
        }


        public async Task sendtogroup(string msg, string gp, string name)
        {
            await Clients.Group(gp).SendAsync("groupmsg", msg, gp, name);
        }

    }
}
