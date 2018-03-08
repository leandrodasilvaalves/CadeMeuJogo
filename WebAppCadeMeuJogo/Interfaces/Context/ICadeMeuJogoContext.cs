using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Interfaces.Context
{
    public interface ICadeMeuJogoContext
    {
        DbSet<Amigo> Amigos { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Emprestimo> Emprestimos { get; set; }
        DbSet<EmprestimoJogo> EmprestimosJogos { get; set; }
        DbSet<Jogo> Jogos { get; set; }

        void Dispose();
        DbEntityEntry Entry(object entity);
        int SaveChanges();
    }
}
