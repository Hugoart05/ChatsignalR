using Microsoft.EntityFrameworkCore;
using SignalR.Chat.Interfaces;
using SignalR.Chat.ViewModels;

namespace SignalR.Chat.Services
{
    public class ChatService : IChatService
    {
        private readonly IContato _contatoRepository;

        public ChatService(IContato contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public IQueryable<UsuarioMensagensViewModel> BuscaTodasMensagens(int id)
        {
            var mensagensDeContato = _contatoRepository.GetAll(x => x.DestinatarioId == id, null, q => q.Destinatario, mensagem => mensagem.Mensagens)
                .Where(x => x.Mensagens.Any())
                .SelectMany(contato => contato.Mensagens
                    .OrderByDescending(x => x.DataDeEnvio)
                    .Select(mensagens => new UsuarioMensagensViewModel
                    {
                        Conteudo = mensagens.Conteudo.ToString(),
                        DataDeEnvio = mensagens.DataDeEnvio,
                        Type = mensagens.Type,
                    }));

            return mensagensDeContato;
        }
    }
}
