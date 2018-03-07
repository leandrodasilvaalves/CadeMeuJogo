using System;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Services
{
    public class AmigoValidation : ValidationBase<Amigo>, IAmigoValidation
    {
        public override bool IsValid(Amigo obj)
        {
            try
            {
                if (!ValidarNome(obj.Nome))
                    throw new Exception("Informe um nome com pelo menos 3 caracteres");

                if (!ValidarDataNascimento(obj.DataNascimento))
                    throw new Exception("Desculpe, é preciso ter pelo menos 12 anos para fazer um empréstimo");

                if (!ValidarCPF(obj.CPF))
                    throw new Exception("Informe um CPF válido");

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarNome(string nome)
        {
            return nome.Length > 2;
        }

        public bool ValidarDataNascimento(DateTime dataNasc)
        {
            return CalcularIdade(dataNasc) > 12;
        }

        public bool ValidarCPF(string cpf)
        {
            if (cpf == String.Empty || cpf ==null) return true; //O CPF não é obrigatório

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private int CalcularIdade(DateTime dtNascimento)
        {
            int idade = DateTime.Now.Year - dtNascimento.Year;
            if (DateTime.Now.Month < dtNascimento.Month || (DateTime.Now.Month == dtNascimento.Month && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;

        }

    }
}