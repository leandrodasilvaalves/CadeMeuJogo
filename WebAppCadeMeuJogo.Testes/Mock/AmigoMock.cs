using System;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Testes.Mock
{
    public static class  AmigoMock
    {
        public static Amigo AmigoDemoValido()
        {
            return new Amigo
            {
                Id = 1,
                Ativo = true,
                Apelido = "Junin",
                Nome = "Francisco Junior",
                CPF = "64596155607",
                DataCadastro = DateTime.Now,
                DataNascimento = new DateTime(1989,2,15)
            };
        }

        public static Amigo AmigoDemoInvalido()
        {
            return new Amigo
            {
                Id = 1,
                Ativo = true,
                Apelido = "Junin",
                Nome = "Fr",
                CPF = "11122233344",
                DataCadastro = DateTime.Now,
                DataNascimento = DateTime.Now
            };
        }
    }
}
