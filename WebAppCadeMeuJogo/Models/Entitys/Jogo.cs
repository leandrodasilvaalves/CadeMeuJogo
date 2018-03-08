using System.Collections.Generic;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Jogo : ClasseBase
    {
        public string Nome { get; set; }
        public bool Disponivel { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        

        public virtual ICollection<EmprestimoJogo> EmprestimoJogo { get; set; }

        public Jogo()
        {
            EmprestimoJogo = new List<EmprestimoJogo>();
        }

    }
}