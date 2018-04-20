using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class BebidasController
    {
        // INSERT
        public static void SalvarBebidas(Bebida bebida)
        {
            ContextoSingleton.Instancia.Bebida.Add(bebida);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static Task<List<Bebida>> ListarTodasBebidas()
        {
            return ContextoSingleton.Instancia.Bebida.ToListAsync(); //IQueryable
        }

        public static void EditarBebida(int id, Bebida novaBebida)
        {
            Bebida bebidaEdit = PesquisarPorID(id);

            if (bebidaEdit != null)
            {
                bebidaEdit.Nome = novaBebida.Nome;
                bebidaEdit.Preco = novaBebida.Preco;
            }

            ContextoSingleton.Instancia.Entry(bebidaEdit).State = EntityState.Modified;

            ContextoSingleton.Instancia.SaveChanges();
        }

        public static void ExcluirBebida(int id)
        {
            Bebida bebidaAtual = ContextoSingleton.Instancia.Bebida.Find(id);

            ContextoSingleton.Instancia.Entry(bebidaAtual).State = EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static Bebida PesquisarPorID(int IDBebida)
        {
            return ContextoSingleton.Instancia.Bebida.Find(IDBebida);
        }

        public static List<Bebida> PesquisarPorNome(string nome)
        {
            return (from x in ContextoSingleton.Instancia.Bebida
                    where x.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase)
                    select x).ToList();
        }
    }
}