using System.Collections.Generic;
using KinopoiskAPI.Hubs.Messages;

namespace KinopoiskAPI.Hubs.Model
{
    public class Connection
    {
        public string ConnectionId { get; set; }
        public bool IsMessagesSend { get; set; } = false;
        public string Sender { get; set; } = "Empty";
        public List<ChatMessage> Messages { get; set; } = new();
    }
}