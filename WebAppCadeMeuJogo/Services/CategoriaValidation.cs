using System;
using WebAppCadeMeuJogo.Interfaces.Services;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Services
{
    public class CategoriaValidation : ValidationBase<Categoria>, ICategoriaValidation
    {
        public override bool IsValid(Categoria categoria)
        {
            try
            {
                if (!ValidarNomeCategoria(categoria.Nome))
                    throw new Exception("O nome da categoria precisa ter  pelo menos 03 caracteres");
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }   
        }

        public bool ValidarNomeCategoria(string nomeCategoria)
        {
            return nomeCategoria.Length > 2;
        }
    }
}