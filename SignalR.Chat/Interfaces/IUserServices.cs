using SignalR.Chat.Models;

namespace SignalR.Chat.Interfaces
{
    public interface IUserService
    {
        Usuario GetUsuarioEmail(string email);
    }
}
