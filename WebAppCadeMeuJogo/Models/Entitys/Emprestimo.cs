using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public class Emprestimo : ClasseBase
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DataFim { get; set; }

        public int AmigoId { get; set; }
        public virtual Amigo Amigo { get; set; }

        public virtual ICollection<EmprestimoJogo> EmprestimosJogos { get; set; }

        public Emprestimo()
        {
            EmprestimosJogos = new List<EmprestimoJogo>();
        }
    }
}