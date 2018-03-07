using System;
using System.Collections.Generic;
using System.Linq;
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
                    throw new Exception("A data fim deve ser maior ou igual a data de início");

                if (!ValidarAmigo(emprestimo.AmigoId))
                    throw new Exception("Informe um amigo para este empréstimo");

                if (!ValidarSeJogoDisponivel(emprestimo.Jogos))
                    throw new Exception("Existe livro que não está disponível na lista.");

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

        public bool ValidarSeJogoDisponivel(ICollection<Jogo> jogos)
        {
            return jogos.Where(j => j.Disponivel).Count() == jogos.Count();
        }
    }
}