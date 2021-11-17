using System.Collections.Generic;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;
using KinopoiskAPI.Hubs.Model;
using KinopoiskAPI.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace KinopoiskAPI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;

        private readonly List<string> _admins = new();

        public ChatHub(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SendMessage(ChatMessage message)
        {
            if (_admins.Count == 0)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", new ChatMessage
                {
                    Sender = "Сервер",
                    Receiver = message.Sender,
                    Message = "Сейчас в сети нет ни одного администратора",
                });
            }
        }

        public async Task ConnectAsAdmin(AdminConnectionMessage message)
        {
            var user = await _userService.GetUser(message.Email);

            if (user != null && (user.Role.Equals(Role.Admin.ToString())))
            {
                _admins.Add(Context.ConnectionId);
            }
        }
    }
}