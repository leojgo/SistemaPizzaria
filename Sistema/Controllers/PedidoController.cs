using Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Controllers
{
    public class PedidoController
    {
        // INSERT
        public static void SalvarPedido(Pedido novo)
        {
            ContextoSingleton.Instancia.Pedido.Add(novo);
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static void MudarStatus(Pedido pedidoAntigo, string status)
        {
            Pedido pedidoEdit = PesquisarPorID(pedidoAntigo.PedidoID);

            if (pedidoEdit != null)
            {
                pedidoEdit.Status = status;
            }

            ContextoSingleton.Instancia.Entry(pedidoEdit).State = EntityState.Modified;
            ContextoSingleton.Instancia.SaveChanges();
        }

        public static List<Pedido> ListarTodosPedidos()
        {
            return ContextoSingleton.Instancia.Pedido.ToList();
        }

        public static List<Pedido> ProcuraPedidoSaiuParaEntrega()
        {
            return (from x in ContextoSingleton.Instancia.Pedido
                    where x.Status.Contains("SAIU PARA ENTREGA")
                    select x).ToList();
        }

        public static List<Pedido> ProcuraPedidoPendentes()
        {
            return (from x in ContextoSingleton.Instancia.Pedido
                    where x.Status.Contains("EM PRODUÇÃO")
                    select x).ToList();
        }

        public static List<Pedido> ProcuraPedidoFinalizado()
        {
            return (from x in ContextoSingleton.Instancia.Pedido
                    where x.Status.Contains("FINALIZADO")
                    select x).ToList();
        }

        public static Pedido PesquisarPorID(int IDPedido)
        {
            return ContextoSingleton.Instancia.Pedido.Find(IDPedido);
        }
    }
}