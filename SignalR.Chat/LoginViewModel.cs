using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SignalR.Chat
{
    public class LoginViewModel
    {
        [Required (ErrorMessage = "Email não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Password é um campo obrigatório!")]
        //[RegularExpression("/^(?=.*[A-Z])(?=.*\\d).+$/", ErrorMessage = "")]
        public string Password { get; set;}
    }
}   
