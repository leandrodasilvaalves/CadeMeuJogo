using System;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public abstract class Pessoa : ClasseBase
    {
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string CPF { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}