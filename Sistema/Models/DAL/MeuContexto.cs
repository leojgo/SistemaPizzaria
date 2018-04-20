using Models;
using Models.DAL.Configurations;
using Models.DAL.Migrations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Sistema.Models.DAL
{
    public class MeuContexto : DbContext
    {
        public MeuContexto() : base("strConn")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MeuContexto>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MeuContexto, Configuration>());
        }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Pizza> Pizza { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Bebida> Bebida { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            AddEntityConfigurations(modelBuilder);
        }

        private void AddEntityConfigurations(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new PizzaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
        }
    }
}