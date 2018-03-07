using System;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Services
{
    public class JogoValidation : ValidationBase<Jogo>, IJogoValidation
    {
        public override bool IsValid(Jogo jogo)
        {
            try
            {
                if (!ValidarNomeJogo(jogo.Nome))
                    throw new Exception("O nome do jogo é obrigatório e deve ter mais pelo menos 02 caracteres");

                if (!ValidarCategoria(jogo.CategoriaId))
                    throw new Exception("Informe a categoria do jogo");
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool ValidarNomeJogo(string NomeJogo)
        {
            return NomeJogo.Length >= 2;
        }

        public bool ValidarCategoria(int categoriaId = 0)
        {
            return categoriaId > 0;
        }
    }
}