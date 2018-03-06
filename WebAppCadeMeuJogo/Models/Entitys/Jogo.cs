using System;
using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Jogo : ClasseBase
    {
        public string Nome { get; set; }        
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public virtual IEnumerable<Emprestimo> Emprestimos { get; set; }

        public Jogo()
        {
            Emprestimos = new List<Emprestimo>();
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}