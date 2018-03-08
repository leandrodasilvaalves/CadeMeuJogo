using System.Collections.Generic;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Testes.Mock
{
    public static class EmprestimoJogoMock
    {
        public static ICollection<EmprestimoJogo> EmprestimoJogoLista()
        {
            return new List<EmprestimoJogo>
            {
                new EmprestimoJogo { Ativo = true, EmprestimoId = 1, JogoId = 1 },
                new EmprestimoJogo { Ativo = true, EmprestimoId = 2, JogoId = 2 },
                new EmprestimoJogo { Ativo = true, EmprestimoId = 3, JogoId = 3 },
                new EmprestimoJogo { Ativo = true, EmprestimoId = 4, JogoId = 4 },
                new EmprestimoJogo { Ativo = true, EmprestimoId = 5, JogoId = 5 },
                new EmprestimoJogo { Ativo = true, EmprestimoId = 6, JogoId = 6 },
            };
        }
    }
}
