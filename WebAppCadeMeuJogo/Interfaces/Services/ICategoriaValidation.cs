using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Interfaces.Services
{
    public interface ICategoriaValidation :IValidationBase<Categoria>
    {
        bool ValidarNomeCategoria(string nomeCategoria);
    }
}
