using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignalR.Chat.Models
{
    public class Contato
    {
        public Contato()
        {
            Destinatario = new();
            Mensagens = new List<Mensagem>();
        }
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        
        public int DestinatarioId { get; set; }
        [JsonIgnore]
        public Usuario Destinatario { get; set; }   
        
        public virtual List<Mensagem> Mensagens { get ; set; }
    }
}