using System;
using System.Collections.Generic;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Services
{
    public class EmprestimoValidation : ValidationBase<Emprestimo>, IEmprestimoValidation
    {
        public override bool IsValid(Emprestimo emprestimo)
        {
            try
            {
                if (!ValidarDataInicio(emprestimo.DataInicio))
                    throw new Exception("A data incio deve ser maior ou igual a data de hoje.");

                if (!ValidarDataFim(emprestimo))
                    throw new Exception("A data fim deve ser maior ou igual a data de início.");

                if (!ValidarAmigo(emprestimo.AmigoId))
                    throw new Exception("Informe um amigo para este empréstimo.");

                if (!ValidarJogos(emprestimo.Jogos))
                    throw new Exception("Um empréstimo deve ter pelo menos um jogo.");

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarDataInicio(DateTime incio)
        {
            return incio.CompareTo(DateTime.Now) >= 0;
        }

        public bool ValidarDataFim(Emprestimo emprestimo)
        {
            return emprestimo.DataInicio.CompareTo(emprestimo.DataFim) >= 0;
        }

        public bool ValidarAmigo(int amigoId = 0)
        {
            return amigoId > 0;
        }

        public bool ValidarJogos(ICollection<Jogo> jogos)
        {
            return jogos.Count > 0;
        }
    }
}