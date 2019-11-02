using Moq;
using MovieCup.Application.ApplicationService;
using MovieCup.Infra.Integration.Filmes.Interface;
using MovieCup.Infra.Integration.Filmes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MovieCup.ApplicationService.Test
{
    public class MovieAppServiceTest
    {
        Mock<IFilmesService> filmesServiceMock;

        MovieAppService movieAppService;
        public MovieAppServiceTest()
        {
            filmesServiceMock = new Mock<IFilmesService>();

            movieAppService = new MovieAppService(filmesServiceMock.Object);
        }
        [Fact]
        public async Task ReturnAllMovies()
        {
            var moviesResponse = new List<FilmesResponse>()
            {
                new FilmesResponse { Id = Guid.NewGuid().ToString(), Score = 7.8, Title = "Fake Movie", Year = 2018 },
                new FilmesResponse { Id = Guid.NewGuid().ToString(), Score = 3.8, Title = "The Fake Movie", Year = 2019 }
            };

            filmesServiceMock.Setup(x => x.GetCurrentChampionship())
                .ReturnsAsync(moviesResponse);

            var response = await movieAppService.GetAll();

            Assert.NotEmpty(response);
            Assert.NotNull(response);
            Assert.Equal(moviesResponse.Count, response.Count());
        }

        [Fact]
        public async Task ReturnNullResponse()
        {
            filmesServiceMock.Setup(x => x.GetCurrentChampionship());

            var response = await movieAppService.GetAll();

            Assert.Empty(response);
            Assert.NotNull(response);
        }
    }
}
