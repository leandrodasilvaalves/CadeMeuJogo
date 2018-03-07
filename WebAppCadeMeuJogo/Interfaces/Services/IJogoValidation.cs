using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Interfaces.Services
{
    public interface IJogoValidation : IValidationBase<Jogo>
    {
        bool ValidarNomeJogo(string NomeJogo);

        bool ValidarCategoria(int categoriaId);
    }
}
