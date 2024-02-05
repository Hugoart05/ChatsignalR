using SignalR.Chat.Interfaces;
using SignalR.Chat.Repository;
using SignalR.Chat.ViewModels;

namespace SignalR.Chat.Business
{
    public class RegrasContato : IRegrasContato
    {
        private readonly IContato _contatoRepository;
        private readonly IUsuario _usuarioRepository;

        public RegrasContato(IContato contatoRepository, IUsuario usuarioRepository)
        {
            _contatoRepository = contatoRepository;
            _usuarioRepository = usuarioRepository;
        }

        //public IQueryable ContatoExisteNaLista(int userId, UsuarioViewModel viewModel)
        //{
            
        //    return usuariosQueEstao;
        //}

        public bool ValidarConfirmacaoDeSolicitacao(int id)
        {
            throw new NotImplementedException();
        }
    }
}
