using MovieCup.Application.ApplicationService;
using MovieCup.Domain.Command.Championship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieCup.ApplicationService.Test
{
    public class ChampionshipAppServiceTest
    {
        ChampionshipAppService appService;

        public ChampionshipAppServiceTest()
        {
            appService = new ChampionshipAppService();
        }

        [Fact]
        public async Task Championship_Succed()
        {
            var mockCommand = MockCommand();

            var result = await appService.Create(mockCommand);
        }

        private AddChampionshipCommand MockCommand()
        {
            return new AddChampionshipCommand()
            {
                Movies = new List<AddMovieChampionshipCommand>
                {
                    new AddMovieChampionshipCommand(){ Id = "tt3606756", Title = "Os Incríveis 2", Year = 2018 ,Score = 8.5},
                    new AddMovieChampionshipCommand(){ Id = "tt4881806", Title = "Jurassic World: Reino Ameaçado", Year = 2018, Score = 6.7},
                    new AddMovieChampionshipCommand(){ Id = "tt5164214", Title = "Oito Mulheres e um Segredo", Year = 2018, Score = 6.3},
                    new AddMovieChampionshipCommand(){ Id = "tt7784604", Title = "Hereditário", Year = 2018, Score = 7.8},
                    new AddMovieChampionshipCommand(){ Id = "tt4154756", Title = "Vingadores: Guerra Infinita", Year = 2018, Score = 8.8},
                    new AddMovieChampionshipCommand(){ Id = "tt5463162", Title = "Deadpool 2", Year = 2018, Score = 8.1},
                    new AddMovieChampionshipCommand(){ Id = "tt3778644", Title = "Han Solo: Uma História Star Wars", Year = 2018, Score = 7.2},
                    new AddMovieChampionshipCommand(){ Id = "tt3501632", Title = "Thor: Ragnarok", Year = 2017, Score = 7.9},
                }
            };
        }
    }
}
