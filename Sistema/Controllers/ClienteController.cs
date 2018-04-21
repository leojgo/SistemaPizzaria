using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Controllers
{
    public class ClienteController
    {
        // INSERT
        public static void SalvarCliente(Cliente cliente)
        {
            ContextoSingleton.Instancia.Cliente.Add(cliente);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public async static Task<List<Cliente>> ListarTodosClientes()
        {
            return await ContextoSingleton.Instancia.Cliente.ToListAsync(); //IQueryable
        }

        public static void EditarCliente(int id, Cliente novoCliente)
        {
            Cliente clienteEdit = PesquisarPorID(id);

            if (clienteEdit != null)
            {
                clienteEdit.Nome = novoCliente.Nome;
                clienteEdit.Cpf = novoCliente.Cpf;
                clienteEdit.Telefone = novoCliente.Telefone;
            }

            ContextoSingleton.Instancia.Entry(clienteEdit).State = EntityState.Modified;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static void ExcluirCliente(int id)
        {
            Cliente clienteAtual = ContextoSingleton.Instancia.Cliente.Find(id);

            ContextoSingleton.Instancia.Entry(clienteAtual).State = EntityState.Deleted;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static List<Cliente> PesquisarPorNome(string nome)
        {
            return (from x in ContextoSingleton.Instancia.Cliente
                    where x.Nome.Equals(nome, System.StringComparison.OrdinalIgnoreCase)
                    select x).ToList();
        }

        public static Cliente PesquisarPorID(int IDCliente)
        {
            return ContextoSingleton.Instancia.Cliente.SingleOrDefault(x => x.ClienteID == IDCliente);
        }

        public static List<Cliente> PesquisarPorTelefone(string tel)
        {
            return (from x in ContextoSingleton.Instancia.Cliente
                    where x.Telefone.Contains(tel)
                    select x).ToList();
        }
    }
}