using SignalR.Chat.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SignalR.Chat.ViewModels
{
    public class RegistroViewModel
    {
        public string Nome { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public string? Message {  get; set; }
    }
}
