using System.Collections.Generic;

namespace Models
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public double Preco { get; set; }

        public virtual ICollection<PedidoPizza> PedidoPizzas { get; set; }

        
    }
}