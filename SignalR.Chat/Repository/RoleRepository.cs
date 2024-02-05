using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;

namespace SignalR.Chat.Repository
{
    public class RoleRepository : RepositoryBase<Role>, IRole
    {
        public RoleRepository(ChatContext conn) : base(conn)
        {
        }
    }
}
