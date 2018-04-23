using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class PedidoBebidaConfiguration : EntityTypeConfiguration<PedidoBebida>
    {
        public PedidoBebidaConfiguration()
        {
            HasKey(p => new { p.PedidoID, p.BebidaID });

            Property(p => p.Quantidade)
                .IsRequired();

            HasRequired(pt => pt.Pedido)
                .WithMany(p => p.Bebidas)
                .HasForeignKey(pt => pt.PedidoID);

            HasRequired(pt => pt.Bebida);
        }
    }
}