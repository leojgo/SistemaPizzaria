using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            ToTable("Cliente");

            HasKey(p => p.ClienteID);

            Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            Property(p => p.Telefone)
                .IsRequired();

            HasRequired(e => e.Endereco)
                .WithRequiredPrincipal(c => c.Cliente);
        }
    }
}