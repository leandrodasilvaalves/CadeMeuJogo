using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public abstract class Pessoa : ClasseBase
    {
        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
    }
}