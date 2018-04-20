using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Controllers
{
    public class PizzaController
    {
        // INSERT
        public static void SalvarPizza(Pizza pizza)
        {
            ContextoSingleton.Instancia.Pizza.Add(pizza);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static List<Pizza> ListarTodasPizzas()
        {
            return ContextoSingleton.Instancia.Pizza.ToList();
        }

        public static void EditarPizza(int id, Pizza novaPizza)
        {
            Pizza pizzaEdit = PesquisarPorID(id);

            if (pizzaEdit != null)
            {
                pizzaEdit.Nome = novaPizza.Nome;
                pizzaEdit.Ingredientes = novaPizza.Ingredientes;
                pizzaEdit.Preco = novaPizza.Preco;
            }

            ContextoSingleton.Instancia.Entry(pizzaEdit).State = EntityState.Modified;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static void ExcluirPizza(int id)
        {
            Pizza pizzaAtual = ContextoSingleton.Instancia.Pizza.Find(id);
            ContextoSingleton.Instancia.Entry(pizzaAtual).State = EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static Pizza PesquisarPorID(int IDPizza)
        {
            return ContextoSingleton.Instancia.Pizza.Find(IDPizza);
        }

        public static List<Pizza> PesquisarPorNome(string nome)
        {
            return (from x in ContextoSingleton.Instancia.Pizza
                    where x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)
                    select x).ToList();
        }
    }
}