using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.EntityConfig
{
    public class EmprestimoJogoConfiguration : EntityTypeConfiguration<EmprestimoJogo>
    {
        public EmprestimoJogoConfiguration()
        {
            ToTable("emprestimo_jogo");

            HasKey(e => new { e.EmprestimoId, e.JogoId });

            Property(e => e.EmprestimoId)
                .HasColumnName("emprestimoId");

            Property(e => e.JogoId)
                .HasColumnName("jogoId");

            Property(e => e.Ativo)
                .HasColumnName("ativo");

            HasRequired(ej => ej.Emprestimo)
                .WithMany(ep => ep.EmprestimosJogos)
                .HasForeignKey(ej => ej.EmprestimoId);

            HasRequired(ej => ej.Jogo)
                .WithMany(jg => jg.EmprestimoJogo)
                .HasForeignKey(ej => ej.JogoId);

        }
    }
}