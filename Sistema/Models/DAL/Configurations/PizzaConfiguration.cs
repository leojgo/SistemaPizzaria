using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace Models.DAL.Configurations
{
    public class PizzaConfiguration : EntityTypeConfiguration<Pizza>
    {
        public PizzaConfiguration()
        {
            ToTable("Pizza");

            HasKey(p => p.PizzaID);

            Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(70)
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_Nome") { IsUnique = true }));

            Property(p => p.Ingredientes);

            Property(p => p.Preco);
        }
    }
}