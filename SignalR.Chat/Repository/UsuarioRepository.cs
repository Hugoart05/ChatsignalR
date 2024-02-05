using Microsoft.EntityFrameworkCore;
using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SignalR.Chat.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuario
    {
        private readonly ChatContext _chatContext;
        private readonly IHttpContextAccessor _contextAccessor;
        public UsuarioRepository(ChatContext conn, ChatContext chatContext, IHttpContextAccessor contextAccessor) : base(conn)
        {
            _chatContext = chatContext;
            _contextAccessor = contextAccessor;
        }

        public Usuario GetUsuarioEmail(string email)
        {
            var user = _chatContext.Usuarios
                .Include(x => x.Role)
                .FirstOrDefault(u => u.Email == email);
            return user;
        }
        
    }
}
