using System.Threading.Tasks;

namespace KinopoiskAPI.Hubs.Clients.Interface
{
    public interface IChatClient
    {
        Task ReceiveMessage(ChatMessage message);
    }
}