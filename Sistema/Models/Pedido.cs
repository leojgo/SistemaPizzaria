using System;
using System.Collections.Generic;

namespace Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<PedidoPizza> Pizzas { get; set; }
        public virtual ICollection<PedidoBebida> Bebidas { get; set; }
        public double ValorTotal { get; set; }
        public StatusPedidoEnum Status { get; set; }
    }
}