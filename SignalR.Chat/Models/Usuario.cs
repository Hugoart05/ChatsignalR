using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignalR.Chat.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Contatos = new List<Contato>();
            Role = new Role();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength (50)]
        [JsonIgnore]
        public string Password { get; set; }
        [Required]
        [MaxLength (100)]
        public string Email { get; set; }
        public virtual List<Contato> Contatos { get; set; }

        [ForeignKey("RoleId")]
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        
    }
}
