using SignalR.Chat.ViewModels;

namespace SignalR.Chat.Interfaces
{
    public interface IChatService
    {
        IQueryable<UsuarioMensagensViewModel> BuscaTodasMensagens(int destinatarioId);
    }
}
