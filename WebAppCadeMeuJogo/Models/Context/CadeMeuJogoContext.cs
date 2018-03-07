using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using WebAppCadeMeuJogo.Interfaces.Context;
using WebAppCadeMeuJogo.Models.EntityConfig;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.Context
{
    public class CadeMeuJogoContext : DbContext, ICadeMeuJogoContext
    {
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }       

        public CadeMeuJogoContext() : base("cademeujogoConexao")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigurarDefault(modelBuilder);
            ConfigurarEntidades(modelBuilder);
        }

        private void ConfigurarDefault(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));
        }

        private void ConfigurarEntidades(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new JogoConfiguration());
            modelBuilder.Configurations.Add(new AmigoConfiguration());
            modelBuilder.Configurations.Add(new EmprestimoConfiguration());
        }

        public override int SaveChanges()
        {
            AutoAtualizarCamposDateTime();
            AutoAtualizarCamposAtivos();
            return base.SaveChanges();
        }

        private void AutoAtualizarCamposDateTime()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }
        }

        private void AutoAtualizarCamposAtivos()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("Ativo") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("Ativo").CurrentValue = Boolean.Parse("true");
                }
            }
        }
        

    }
}
