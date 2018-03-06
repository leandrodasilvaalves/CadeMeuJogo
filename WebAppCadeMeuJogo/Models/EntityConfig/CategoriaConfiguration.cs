using System.Data.Entity.ModelConfiguration;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.EntityConfig
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            ToTable("categoria");

            HasKey(c => c.Id);
            Property(c => c.Id)
                .HasColumnName("id");

            Property(c => c.Ativo)
                .HasColumnName("ativo")
                .IsRequired();

            Property(c => c.DataCadastro)
                .HasColumnName("dataCadastro");

            Property(c => c.Nome)
                .HasColumnName("nome");

        }
    }
}