using SignalR.Chat.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.Chat.ViewModels
{
    public class ContatoViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string? UltimaMensagem { get; set; }
        public string? CreatedAt { get; set; }
    }
}
