using System;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Testes.Mock
{
    public static class CategoriaMock
    {
        public static Categoria CategoriaDemoValida()
        {
            return new Categoria {  Id =1, Ativo =true, DataCadastro = DateTime.Now, Nome="Aventura"};
        }

        public static Categoria CategoriaDemoInvalida()
        {
            return new Categoria { Id = 1, Ativo = true, DataCadastro = DateTime.Now, Nome = "Av" };
        }
    }
}
