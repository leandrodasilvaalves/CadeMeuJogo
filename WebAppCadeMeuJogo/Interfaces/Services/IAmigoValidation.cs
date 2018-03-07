using System;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Interfaces.Services
{
    public interface IAmigoValidation :  IValidationBase<Amigo>
    {
        bool ValidarNome(string nome);

        bool ValidarDataNascimento(DateTime dataNasc);

        bool ValidarCPF(string cpf);
    }
}
