using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SignalR.Chat.Models
{
    public class Mensagem
    {
        public Mensagem()
        {
            Contato = new Contato();
        }
        public int Id { get; set; }

        [Required]
        public DateTime DataDeEnvio { get; set; }
        public string Type {  get; set; }
        public string Conteudo { get; set; }
        [ForeignKey("ContatoId")]
        public int ContatoId { get; set; }

        [JsonIgnore]
        public virtual Contato Contato { get; set; }
    }
}
