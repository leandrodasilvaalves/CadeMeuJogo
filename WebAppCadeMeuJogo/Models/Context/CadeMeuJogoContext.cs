using System.Data.Entity;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.Context
{
    public class CadeMeuJogoContext : DbContext
    {
        public DbSet<Amigo> Amigos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }

        public CadeMeuJogoContext():base("cademeujogoConexao")
        {
        }





    }
}