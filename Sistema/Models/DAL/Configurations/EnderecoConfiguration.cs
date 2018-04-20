using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            HasKey(p => p.ClienteID);

            Property(p => p.ClienteID)
                .IsRequired();

            Property(p => p.Rua)
                .IsRequired();

            Property(p => p.Numero)
                .IsRequired();

            Property(p => p.Bairro)
                .IsRequired();

            Property(p => p.Complemento)
                .IsOptional();

            Property(p => p.Referencia)
                .IsOptional();

            HasRequired(p => p.Cliente)
                .WithRequiredDependent(e => e.Endereco);
        }
    }
}