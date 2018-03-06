using System.Data.Entity.ModelConfiguration;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.EntityConfig
{
    public class EmprestimoConfiguration : EntityTypeConfiguration<Emprestimo>
    {
        public EmprestimoConfiguration()
        {
            ToTable("emprestimo");

            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("id");

            Property(e => e.Ativo)
                .HasColumnName("ativo");

            Property(e => e.DataCadastro)
                .HasColumnName("dataCadastro");

            Property(e => e.DataInicio)
                .HasColumnName("dataInicio")
                .IsRequired();

            Property(e => e.DataFim)
                .HasColumnName("dataFim")
                .IsRequired();

            Property(e => e.AmigoId)
                .HasColumnName("amigoId");

            HasRequired(e => e.Amigo)
                .WithMany(a => a.Emprestimos)
                .HasForeignKey(e => e.AmigoId);
           
            HasMany(e => e.Jogos)
                .WithMany(j => j.Emprestimos)
                .Map(m =>
               {
                   m.ToTable("emprestimos_jogos");
                   m.MapLeftKey("emprestimoId");
                   m.MapRightKey("jogoId");
               });



        }
    }
}