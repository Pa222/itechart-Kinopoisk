using System.Threading.Tasks;
using KinopoiskAPI.Hubs.Clients.Interface;
using Microsoft.AspNetCore.SignalR;

namespace KinopoiskAPI.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(ChatMessage message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}