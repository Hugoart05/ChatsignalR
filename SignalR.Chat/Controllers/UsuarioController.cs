using Microsoft.AspNetCore.Mvc;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;
using SignalR.Chat.ViewModels;
using System.Security.Claims;

namespace SignalR.Chat.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuario _usuarioRepository;
        private readonly IContato _contatoRepository;
        private readonly IRegrasContato _regrasContato;

        public UsuarioController(IUsuario usuarioRepository, IContato contatoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _contatoRepository = contatoRepository;
        }

        [HttpPost("AddContact")]
        public IActionResult AdicionarContato()
        {

        }
        [HttpPost]
        public IActionResult GetUsuariosByNickName([FromBody] UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                var usuarios = _usuarioRepository.GetAll(x => x.Nome.Contains(viewModel.Name) || x.Email.StartsWith(viewModel.Name));
                var contatos = _contatoRepository.GetAll(x => x.UsuarioId == user.);
                var usuarioNaListadeContatos = contatos.Select(x => x.DestinatarioId);
                var usuariosQueEstao = usuarios.Select(u => new
                {
                    Id = u.Id,
                    Name = u.Nome,
                    IsExist = usuarioNaListadeContatos.Contains(u.Id)
                });
                if (usuariosQueEstao.Any())
                {
                    return Json(usuariosQueEstao);
                }
                return Json(null);
            }
            return BadRequest("Caracteres invalidos");
        }
    }
}
