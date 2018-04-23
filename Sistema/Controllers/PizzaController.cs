using Models;
using Sistema.Models.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Controllers
{
    public static class PizzaController
    {
        // INSERT
        public async static void SalvarPizza(Pizza pizza)
        {
            using (var db = new MeuContexto())
            {
                db.Pizza.Add(pizza);
                await db.SaveChangesAsync();
            }
        }

        public static Task<List<Pizza>> ListarTodasPizzas()
        {
            return new MeuContexto().Pizza.ToListAsync();
        }

        public static IQueryable<Pizza> GetAll()
        {
            return new MeuContexto().Set<Pizza>();
        }

        public static IQueryable<Pizza> GetAllIncluding(params Expression<Func<Pizza, object>>[] propertySelectors)
        {
            if (propertySelectors.IsNullOrEmpty())
            {
                return GetAll();
            }

            var query = GetAll();

            foreach (var propertySelector in propertySelectors)
            {
                query = query.Include(propertySelector);
            }

            return query;
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