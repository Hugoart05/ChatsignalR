using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;

namespace SignalR.Chat.Repository
{
    public class MensagemRepository : RepositoryBase<Mensagem>, IMensagem
    {
        public MensagemRepository(ChatContext conn) : base(conn)
        {
        }
    }
}
