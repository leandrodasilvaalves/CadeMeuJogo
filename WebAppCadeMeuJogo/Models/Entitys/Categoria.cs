using System;
using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Categoria : ClasseBase
    {
        public string Nome { get; set; }
        public virtual ICollection<Jogo> Jogos { get; set; }

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