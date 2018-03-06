using System;

namespace WebAppCadeMeuJogo.Models.Entitys
{
    public abstract class ClasseBase
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }

        public abstract bool IsValid();
    }
}