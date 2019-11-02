using Moq;
using MovieCup.Application.ApplicationService;
using MovieCup.Domain;
using MovieCup.Domain.Command.Championship;
using MovieCup.Domain.Interface.Application;
using MovieCup.Domain.ModelView.Movie;
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
        Mock<IMovieAppService> movieAppServiceMock;
        public ChampionshipAppServiceTest()
        {
            movieAppServiceMock = new Mock<IMovieAppService>();

            appService = new ChampionshipAppService(movieAppServiceMock.Object);
        }

        [Fact]
        public async Task Champion()
        {
            movieAppServiceMock.Setup(x => x.GetAll())
             .ReturnsAsync(MockMovieViewModel());

            var mockCommand = MockCommand();
            var result = await appService.Create(mockCommand);
            Assert.Equal("Vingadores: Guerra Infinita", result.Title);
        }

        [Fact]
        public void Tiebreaker()
        {
            movieAppServiceMock.Setup(x => x.GetAll())
             .ReturnsAsync(MockMovieViewModel());

            var mockCommand = MockCommand();
            mockCommand.Movies.First(x => x.Id == "tt5463162").Score = mockCommand.Movies.First(x => x.Id == "tt4154756").Score;

            var result = appService.Create(mockCommand).Result;

            Assert.Equal("Deadpool 2", result.Title);
        }

        [Fact]
        public void Throw_Invalid_Movie_Quantities()
        {
            var mockCommand = MockCommand();
            mockCommand.Movies.RemoveRange(0, 1);

            var result = Assert.ThrowsAsync<ApplicationException>(() => appService.Create(mockCommand)).Result;

            Assert.Equal(string.Format(ResourceMessage.InvalidCommand, "Movies"), result.Message);
        }

        [Fact]
        public void Throw_IfNull()
        {
            var result = Assert.ThrowsAsync<ArgumentNullException>(() => appService.Create(null)).Result;

            Assert.Equal("Value cannot be null. (Parameter 'command')", result.Message);
        }

        [Fact]
        public void Throw_Invalid_Movie()
        {
            var mockCommand = MockCommand();
            mockCommand.Movies.First().Id = "123test";

            movieAppServiceMock.Setup(x => x.GetAll())
                .ReturnsAsync(MockMovieViewModel());

            var result = Assert.ThrowsAsync<ApplicationException>(() => appService.Create(mockCommand)).Result;

            Assert.Equal(string.Format(ResourceMessage.NotExist, "Movies"), result.Message);
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

        IEnumerable<MovieViewModel> MockMovieViewModel()
        {
            return new List<MovieViewModel>
            {
                new MovieViewModel("tt3606756", "OsIncríveis2" ,2018,8.5),
                new MovieViewModel("tt4881806", "JurassicWorld:ReinoAmeaçado",2018,6.7),
                new MovieViewModel("tt5164214", "OitoMulhereseumSegredo",2018,6.3),
                new MovieViewModel("tt7784604", "Hereditário",2018,7.8),
                new MovieViewModel("tt4154756", "Vingadores:GuerraInfinita",2018,8.8),
                new MovieViewModel("tt5463162", "Deadpool2",2018,8.1),
                new MovieViewModel("tt3778644", "HanSolo:UmaHistóriaStarWars",2018,7.2),
                new MovieViewModel("tt3501632", "Thor:Ragnarok",2017,7.9),
            };
        }
    }
}
