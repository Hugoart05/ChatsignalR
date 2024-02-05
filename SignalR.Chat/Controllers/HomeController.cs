using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.Chat.ExtensionMethods;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;
using SignalR.Chat.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace SignalR.Chat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContato _contatoRepository;
        private readonly IUsuario _usuarioRepository;

        public HomeController(IUsuario usuarioRepository, IContato contatoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contatoRepository = contatoRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            try
            {                
                var userId = int.Parse(User.Identity.Name);
                var UserNmae = User.GetUserName();
                var viewModel = _contatoRepository.GetAll(x => x.UsuarioId == userId, null, q => q.Destinatario, m => m.Mensagens)
                    .Where(contato => contato.Mensagens.Any())
                    .Select(contato => new ContatoViewModel
                    {
                        Id = contato.Id,
                        Nome = contato.Destinatario.Nome,
                        CreatedAt = contato.Mensagens.OrderByDescending(x => x.DataDeEnvio).First().DataDeEnvio.ToString("dd/MM/yy HH:mm"),
                        UltimaMensagem = contato.Mensagens.OrderByDescending(x => x.DataDeEnvio).First().Conteudo.ToString()
                    }).ToList();
                ;
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return View(null);
            }
        }
    }
}
