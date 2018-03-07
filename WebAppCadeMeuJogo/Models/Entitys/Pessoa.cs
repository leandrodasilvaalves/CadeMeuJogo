using System;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public abstract class Pessoa : ClasseBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
    }
}