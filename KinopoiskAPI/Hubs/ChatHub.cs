using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer.Entity;
using KinopoiskAPI.Hubs.Messages;
using KinopoiskAPI.Hubs.Model;
using KinopoiskAPI.Services.Interfaces;
using KinopoiskAPI.Utils.Jwt;
using Microsoft.AspNetCore.SignalR;

namespace KinopoiskAPI.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IUserService _userService;

        private static readonly List<string> Admins = new();

        private static readonly List<Connection> Connections = new();

        public ChatHub(IUserService userService)
        {
            _userService = userService;
        }

        public override Task OnConnectedAsync()
        {
            Connections.Add(new Connection { ConnectionId = Context.ConnectionId });
            return base.OnConnectedAsync();
        }

        public override async Task<Task> OnDisconnectedAsync(Exception exception)
        {
            Connections.Remove(Connections.First(c => c.ConnectionId.Equals(Context.ConnectionId)));
            if (Admins.Any(admin => admin.Equals(Context.ConnectionId)))
                Admins.Remove(Context.ConnectionId);
            await GetAdminInformation();
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessageToAdmin(ChatMessage message)
        {
            var connection = Connections.FirstOrDefault(c => c.ConnectionId.Equals(Context.ConnectionId));
            if (connection != null)
            {
                connection.Sender = message.Sender;
                connection.IsMessagesSend = true;
                connection.Messages.Add(message);
            }

            if (Admins.Count == 0)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", new ChatMessage
                {
                    Sender = "Сервер",
                    Receiver = message.Sender,
                    Message = "Сейчас в сети нет ни одного администратора",
                });
            }
            else
            {
                foreach (var admin in Admins)
                {
                    await Clients.Client(admin).SendAsync("UpdateAdminInformation");
                }
            }
        }

        public async Task ConnectAsAdmin(AdminConnectionRequestMessage requestMessage)
        {
            var email = JwtDecoder.GetEmail(requestMessage.Token[7..]);

            var user = await _userService.GetUser(email);

            if (user != null && (user.Role.Equals(Role.Admin.ToString())))
            {
                if (Connections.Any(c => c.ConnectionId.Equals(Context.ConnectionId)) && !Admins.Contains(Context.ConnectionId))
                {
                    Admins.Add(Context.ConnectionId);
                }
            }
        }

        public async Task GetAdminInformation()
        {
            var connections = Connections.Where(connection => connection.IsMessagesSend);
            foreach (var admin in Admins)
            {
                await Clients.Client(admin).SendAsync("ReceiveAdminInformation", connections);
            }
        }

        public async Task GetMyMessages(string connectionId)
        {
            var connection = Connections.FirstOrDefault(c => c.ConnectionId.Equals(connectionId));

            if (connection != null)
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMyMessages", connection.Messages);
            }
        }
    }
}