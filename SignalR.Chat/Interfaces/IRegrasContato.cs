using SignalR.Chat.ViewModels;

namespace SignalR.Chat.Interfaces
{
    public interface IRegrasContato
    {
        //IQueryable ContatoExisteNaLista(int id, UsuarioViewModel viewModel);
        bool ValidarConfirmacaoDeSolicitacao(int id);
    }
}
