using System.Collections.Generic;

namespace Models
{
    public class Cliente : Pessoa
    {
        public int ClienteID { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}