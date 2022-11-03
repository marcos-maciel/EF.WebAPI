using EF.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.WebApi.TestMoq.MockData
{
    public class FilmeMockData
    {
        public static List<Filme> GetAll()
        {
            return new List<Filme>()
            {
                new Filme
                {
                    Id = 1,
                    Nome = "Filme1",
                    Diretor = "John",
                    Duracao = 120
                },
                new Filme
                {
                    Id = 2,
                    Nome = "NovoFilme2",
                    Diretor = "Sara",
                    Duracao = 90
                },
                new Filme
                {
                    Id = 3,
                    Nome = "AddFilme3",
                    Diretor = "Marcos",
                    Duracao = 87
                }
            };
        }

        public static Filme AddFilme()
        {
            return new Filme
            {
                Id = 4,
                Nome = "AddFilme4",
                Diretor = "Mary",
                Duracao = 65
            };
        }
    }
}
