using Domain;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class Context : DbContext
    {
        #region Contrutores

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        #endregion

        #region Propriedades

        public DbSet<Apolice> Apolice { get; set; }

        public DbSet<ApoliceVida> ApoliceVida { get; set; }

        public DbSet<Vida> Vida { get; set; }

        #endregion

        #region Métodos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Apolice>().Property("Valor").HasColumnType("decimal(19,0)");
            builder.Entity<ApoliceVida>().Ignore("VidasPossiveis")
                                         .Ignore("ApolicesPossiveis");
            builder.Entity<Vida>().Ignore("VidasPossiveis");

            base.OnModelCreating(builder);
        }

        private static string GetStringConectionConfig()
        {
            return "Data Source=DESKTOP-RPGUSJ3;Initial Catalog=SeguradoraDeVida;Integrated Security=False;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }

        #endregion Métodos
    }
}