using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignalR.Chat.Models
{
    public class Role
    {
        public Role()
        {
            Usuarios = new List<Usuario>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Usuario> Usuarios { get; set; }
    }
}
