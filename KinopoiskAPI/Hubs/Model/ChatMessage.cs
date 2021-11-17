namespace KinopoiskAPI.Hubs.Model
{
    public class ChatMessage
    {
        public string Receiver { get; set; } = "-1";
        public string Sender { get; set; }
        public string Message { get; set; }
    }
}