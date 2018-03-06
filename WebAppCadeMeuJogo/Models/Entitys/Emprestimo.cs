using System;
using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Emprestimo : ClasseBase
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

        public int AmigoId { get; set; }
        public virtual Amigo Amigo { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }

        public Emprestimo()
        {
            Jogos = new List<Jogo>();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}