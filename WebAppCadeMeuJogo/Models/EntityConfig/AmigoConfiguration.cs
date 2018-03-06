using System.Data.Entity.ModelConfiguration;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.EntityConfig
{
    public class AmigoConfiguration : EntityTypeConfiguration<Amigo>
    {
        public AmigoConfiguration()
        {
            ToTable("amigo");

            HasKey(a => a.Id);
            Property(a => a.Id)
                .HasColumnName("id");

            Property(a => a.Ativo)
                .HasColumnName("ativo");

            Property(a => a.DataCadastro)
                .HasColumnName("dataCadastro");

            Property(a => a.Nome)
                .HasColumnName("nome")
                .IsRequired();

            Property(a => a.DataNascimento)
                .HasColumnName("dataNascimento");

            Property(a => a.CPF)
                .HasColumnName("cpf");

            Property(a => a.Apelido)                
                .HasColumnName("apelido");


        }

    }
    
}