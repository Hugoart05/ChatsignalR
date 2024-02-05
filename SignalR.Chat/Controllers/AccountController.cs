using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Models;
using SignalR.Chat.ViewModels;
using System.Security.Claims;

namespace SignalR.Chat.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsuario _userRepository;
        private readonly IRole _roleRepository;

        public AccountController(IUsuario userRepository, IRole roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");
            }
            return View();
        }

        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(RegistroViewModel viewModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            if (ModelState.IsValid)
            {
                var userExist = _userRepository.GetAll(x => x.Email == viewModel.Email || x.Nome == viewModel.Nome).Count();
                if (userExist > 0)
                {
                    return View("registro", new RegistroViewModel { Message = "Email ou nome de usuário ja cadastrado." });
                }
                var user = new Usuario
                {
                    Email = viewModel.Email,
                    Nome = viewModel.Nome,
                    Password = viewModel.Password,
                    RoleId = 2//usuario comum e 1 usuario admin

                };
                _userRepository.Add(user);
                return View("index");
            }
            return View("registro", new RegistroViewModel { Message = "Todos os campos são requeridos." });
        }

        [HttpPost]
        public IActionResult FazerLogin(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _userRepository.GetUsuarioEmail(viewModel.Email);
                    if (user != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, user.Nome),
                            new Claim(ClaimTypes.Name, user.Nome),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Role, user.Role.Name)
                           
                        };

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.NameIdentifier,ClaimTypes.Role);

                        var authProperties = new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.Now.AddDays(1),
                            IsPersistent = true,
                            IssuedUtc = DateTime.Now.AddDays(1)
                        };

                        HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return RedirectToAction("index", "Home");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("MESSAGE AQUI: " + ex.Message);
                }
            }
            return View("index");
        }

        public IActionResult Sair()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("index");
            }
            HttpContext.SignOutAsync();
            return RedirectToAction("index");
        }
    }
}
