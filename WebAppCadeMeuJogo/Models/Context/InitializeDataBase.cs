using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebAppCadeMeuJogo.Models.Entitys;

namespace WebAppCadeMeuJogo.Models.Context
{
    public class InitializeDataBase : CreateDatabaseIfNotExists<CadeMeuJogoContext>
    {
        protected override void Seed(CadeMeuJogoContext context)
        {
            var Categorias = new List<Categoria>
            {
                new Categoria{ Nome = "Futebol",
                    Jogos = new List<Jogo>
                    {
                        new Jogo{ Nome = "Fifa 17", Disponivel = true},
                        new Jogo{ Nome = "Pro Evolution Soccer 2018", Disponivel = true}
                    }
                },
                new Categoria{ Nome= "Luta",
                    Jogos = new List<Jogo>
                    {
                        new Jogo{ Nome = "Mortal Kombat 2011", Disponivel = true},
                        new Jogo{ Nome = "Mortal Kombat vs. DC Universe", Disponivel = true},
                        new Jogo{ Nome = "wwe 2k 16", Disponivel = true},
                        new Jogo{ Nome = "Street Fighter IV", Disponivel = true},
                        new Jogo{ Nome = "Dragon Ball Xenoverse", Disponivel = true}
                    }
                },
                new Categoria{ Nome = "Tiro",
                    Jogos = new List<Jogo>
                    {
                        new Jogo{ Nome = "Farcry 4", Disponivel = true},
                        new Jogo{ Nome = "Battle Field 4", Disponivel = true},
                        new Jogo{ Nome = "Call of Duty: Black Ops", Disponivel = true},
                        new Jogo{ Nome = "Grand Theft Auto V", Disponivel = true}
                    }
                },
                new Categoria{ Nome = "Terror",
                    Jogos = new List<Jogo>
                    {
                        new Jogo{ Nome = "Deadly Premonition", Disponivel = true},
                        new Jogo{ Nome = "Clive Barker's Jericho" , Disponivel = true},
                        new Jogo{ Nome = "Alone in the Dark (2008)", Disponivel = true}
                    }
                }
            };
            var Amigos = new List<Amigo>
            {
                new Amigo{ Nome = "Ricardo", DataNascimento = new DateTime(1980,10,2)},
                new Amigo{ Nome = "Gleisson", Apelido = "Narizinho", DataNascimento = new DateTime(1996,2,3)},
                new Amigo{ Nome = "Nilton", Apelido = "Escuro", DataNascimento = new DateTime(1995,8,21)},
                new Amigo{ Nome = "Jose Francisco", Apelido = "Mannyn", DataNascimento = new DateTime(1983,11,15)},
                new Amigo{ Nome = "Carlos Eduardo", Apelido = "Cadu", DataNascimento = new DateTime(1982,11,12)},
                new Amigo{ Nome = "Roberto", Apelido = "Betão", DataNascimento = new DateTime(1999,7,12)},
                new Amigo{ Nome = "Gilson", DataNascimento = new DateTime(1993,3,11)},
                new Amigo{Nome = "Jefferson", Apelido = "Papa", DataNascimento = new DateTime(1998,9,17)}
            };

            context.Categorias.AddRange(Categorias);
            context.Amigos.AddRange(Amigos);

            base.Seed(context);
        }
    }
}