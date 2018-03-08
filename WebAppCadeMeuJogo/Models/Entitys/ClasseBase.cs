using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public abstract class ClasseBase
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

    }
}