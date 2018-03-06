using System.Data.Entity.ModelConfiguration;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.EntityConfig
{
    public class JogoConfiguration : EntityTypeConfiguration<Jogo>
    {
        public JogoConfiguration()
        {
            ToTable("jogo");

            HasKey(j => j.Id);
            Property(c => c.Id)
                .HasColumnName("id");

            Property(j => j.Ativo)
                .HasColumnName("ativo");

            Property(j => j.DataCadastro)
                .HasColumnName("dataCadastro");

            Property(j => j.Nome)
                .HasColumnName("nome")
                .IsRequired();

            Property(j => j.CategoriaId)
                .HasColumnName("categoriaId");

            HasRequired(j => j.Categoria)
                .WithMany(c => c.Jogos)
                .HasForeignKey(j => j.CategoriaId);
        }
    }
}