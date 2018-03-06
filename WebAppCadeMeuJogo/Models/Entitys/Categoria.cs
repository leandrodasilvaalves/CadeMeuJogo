using System;
using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Categoria : ClasseBase
    {
        public int Nome { get; set; }
        public virtual IEnumerable<Jogo> Jogos { get; set; }

        public Categoria()
        {
            Jogos = new List<Jogo>();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}