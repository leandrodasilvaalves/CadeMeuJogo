using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Amigo : Pessoa
    {
        public int Apelido { get; set; }

        public IEnumerable<Emprestimo> Emprestimos { get; set; }

        public Amigo()
        {
            Emprestimos = new List<Emprestimo>();
        }
    }
}