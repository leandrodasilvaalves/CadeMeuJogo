using System;
using System.Collections.Generic;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Testes.Mock
{
    public static class JogoMock
    {
        public static ICollection<Jogo> JogosLista()
        {
            return new List<Jogo>
            {
                new Jogo{ Id = 1, Nome = "Mortal Kombat 2011", Disponivel = true, CategoriaId = 1, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 2, Nome = "Mortal Kombat vs. DC Universe", Disponivel = false, CategoriaId = 1, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 3, Nome = "wwe 2k 16", Disponivel = true, CategoriaId = 1, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 4, Nome = "Street Fighter IV", Disponivel = true, CategoriaId = 1, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 5, Nome = "Dragon Ball Xenoverse", Disponivel = false, CategoriaId = 1, DataCadastro = DateTime.Now, Ativo = true},

                new Jogo{ Id = 6, Nome = "Farcry 4", Disponivel = true, CategoriaId = 2, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 7, Nome = "Battle Field 4", Disponivel = true, CategoriaId = 2, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 8, Nome = "Call of Duty: Black Ops", Disponivel = true, CategoriaId = 2, DataCadastro = DateTime.Now, Ativo = true},
                new Jogo{ Id = 9, Nome = "Grand Theft Auto V", Disponivel = true, CategoriaId = 2, DataCadastro = DateTime.Now, Ativo = true}
            };
        }

        public static ICollection<Jogo> JogoListaVazia()
        {
            return new List<Jogo>();
        }
    }
}
