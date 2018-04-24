using Models;
using Sistema.Models.DAL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Controllers
{
    public class PedidoController
    {
        // INSERT
        public static void SalvarPedido(Pedido pedido)
        {
            using (var db = new MeuContexto())
            {
                db.Pedido.Add(pedido);
                db.SaveChanges();
            }
        }

        public static void MudarStatus(Pedido pedidoAntigo, StatusPedidoEnum status)
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
                    where x.Status == StatusPedidoEnum.Saiu_Para_Entrega
                    select x).ToList();
        }

        public static List<Pedido> ProcuraPedidoPendentes()
        {
            return (from x in ContextoSingleton.Instancia.Pedido
                    where x.Status == StatusPedidoEnum.Em_Producao
                    select x).ToList();
        }

        public static List<Pedido> ProcuraPedidoFinalizado()
        {
            return (from x in ContextoSingleton.Instancia.Pedido
                    where x.Status == StatusPedidoEnum.Finalizado
                    select x).ToList();
        }

        public static Pedido PesquisarPorID(int IDPedido)
        {
            return ContextoSingleton.Instancia.Pedido.Find(IDPedido);
        }
    }
}