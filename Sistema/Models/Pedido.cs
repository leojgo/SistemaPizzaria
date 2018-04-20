using System;

namespace Models
{
    public class Pedido
    {
        public int PedidoID { get; set; }
        public int ClientID { get; set; }
        public DateTime Data { get; set; }
        public Pizza Pizza { get; set; }
        public Bebida Bebida { get; set; }
        public double ValorTotal { get; set; }
        public string Status { get; set; }
    }
}