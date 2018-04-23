namespace Models
{
    public class PedidoPizza
    {
        public int PedidoID { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int PizzaID { get; set; }
        public virtual Pizza Pizza { get; set; }
        public int Quantidade { get; set; }
        public TamanhoPizzaEnum Tamanho { get; set; }
    }
}