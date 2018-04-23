using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class PedidoPizzaConfiguration : EntityTypeConfiguration<PedidoPizza>
    {
        public PedidoPizzaConfiguration()
        {
            HasKey(p => new { p.PedidoID, p.PizzaID });

            Property(p => p.Quantidade)
                .IsRequired();

            Property(p => p.Tamanho)
                .IsRequired();

            HasRequired(pt => pt.Pedido)
                .WithMany(p => p.Pizzas)
                .HasForeignKey(pt => pt.PedidoID);

            HasRequired(pt => pt.Pizza);
        }
    }
}