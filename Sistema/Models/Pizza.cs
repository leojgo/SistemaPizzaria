using System.Collections.Generic;

namespace Models
{
    public class Pizza : IEqualityComparer<Pizza>
    {
        public int PizzaID { get; set; }
        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public double Preco { get; set; }

        public bool Equals(Pizza x, Pizza y)
        {
            return x.Nome == y.Nome;
        }

        public int GetHashCode(Pizza obj)
        {
            return obj.Nome.GetHashCode();
        }
    }
}