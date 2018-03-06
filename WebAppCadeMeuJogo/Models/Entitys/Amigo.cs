using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Amigo : Pessoa
    {
        public string Apelido { get; set; }

        public ICollection<Emprestimo> Emprestimos { get; set; }

        public Amigo()
        {
            Emprestimos = new List<Emprestimo>();
        }
    }
}