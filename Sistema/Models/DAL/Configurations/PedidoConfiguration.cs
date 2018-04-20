using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasKey(p => p.PedidoID);

            Property(p => p.ClientID)
                .IsRequired();

            Property(p => p.Data)
                .IsRequired();

            Property(p => p.Status);

            Property(p => p.ValorTotal)
                .IsRequired();

            HasRequired<Pizza>(p => p.Pizza);

            HasOptional<Bebida>(p => p.Bebida);
        }
    }
}