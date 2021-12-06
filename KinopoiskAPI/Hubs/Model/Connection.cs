using KinopoiskAPI.Hubs.Messages;
using System.Collections.Generic;

namespace KinopoiskAPI.Hubs.Model
{
    public class Connection
    {
        public string ConnectionId { get; set; }
        public bool IsMessagesSend { get; set; } = false;
        public bool IsReplied { get; set; } = false;
        public string Sender { get; set; } = ChatDefaultValues.Empty;
        public List<ChatMessage> Messages { get; set; } = new();
    }
}