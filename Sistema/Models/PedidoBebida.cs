namespace Models
{
    public class PedidoBebida
    {
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int BebidaID { get; set; }
        public virtual Bebida Bebida { get; set; }
        public int Quantidade { get; set; }
    }
}