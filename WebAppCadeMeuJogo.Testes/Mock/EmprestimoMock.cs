using System;
using System.Collections.Generic;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Testes.Mock
{
    public static class EmprestimoMock
    {
        public static Emprestimo EmprestimoDemoValido()
        {
            return new Emprestimo
            {
                Id = 1,
                Amigo = AmigoMock.AmigoDemoValido(),
                AmigoId = AmigoMock.AmigoDemoValido().Id,
                Ativo = true,
                DataCadastro = DateTime.Now,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(10),
                Jogos = JogoMock.JogosLista()
            };
        }

        public static Emprestimo EmprestimoDemoInvalido()
        {
            return new Emprestimo
            {
                Id = 1,
                Ativo = true,
                DataCadastro = DateTime.Now,
                DataInicio = DateTime.Now.AddDays(-2),
                DataFim = DateTime.Now.AddDays(-10),
                Jogos = new List<Jogo>()
            };
        }
    }
}
