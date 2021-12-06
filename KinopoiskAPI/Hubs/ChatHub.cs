using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        private static readonly List<Connection> Connections = new();

        private const string AdminGroupName = "Admins";

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
                connection.IsReplied = false;
                connection.Messages.Add(message);
                await Clients.Group(AdminGroupName).SendAsync(HubMethods.UpdateAdminInformation);
                await Clients.Group(AdminGroupName).SendAsync(HubMethods.ReceiveMessages, connection.Messages);
            }
        }

        public async Task SendMessageToUser(ChatMessage message)
        {
            var connection = Connections.FirstOrDefault(c => c.Sender.Equals(message.Receiver));

            if (connection != null)
            {
                connection.Messages.Add(message);
                connection.IsReplied = true;
                await Clients.Caller.SendAsync(HubMethods.UpdateAdminInformation);
                await Clients.Client(connection.ConnectionId).SendAsync(HubMethods.ReceiveMessage, message);
            }
        }

        public async Task ConnectAsAdmin(AdminConnectionRequestMessage requestMessage)
        {
            var email = JwtDecoder.GetEmail(requestMessage.Token[7..]);

            var user = await _userService.GetUser(email);

            if (user != null && (user.Role.Equals(Role.Admin.ToString())))
            {
                if (Connections.Any(c => c.ConnectionId.Equals(Context.ConnectionId)))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, AdminGroupName);
                }
            }
        }

        public async Task GetAdminInformation()
        {
            var connections = Connections.Where(connection => connection.IsMessagesSend);
            await Clients.Group(AdminGroupName).SendAsync(HubMethods.ReceiveAdminInformation, connections);
        }
    }
}