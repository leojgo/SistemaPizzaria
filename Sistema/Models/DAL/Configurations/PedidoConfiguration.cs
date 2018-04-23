using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(p => p.PedidoID);

            HasRequired(p => p.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(p => p.ClienteID);

            Property(p => p.Data)
                .IsRequired();

            Property(p => p.Status);

            Property(p => p.ValorTotal)
                .IsRequired();

            HasMany(p => p.Pizzas)
                .WithRequired().HasForeignKey(p => p.PizzaID);

            HasMany(p => p.Bebidas)
                .WithRequired().HasForeignKey(p => p.BebidaID);
        }
    }
}