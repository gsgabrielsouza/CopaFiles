using MovieCup.Domain.Interface.Application;
using MovieCup.Domain.ModelView.Movie;
using MovieCup.Infra.Integration.Filmes.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCup.Application.ApplicationService
{
    public class MovieAppService : IMovieAppService
    {
        private readonly IFilmesService filmesService;

        public MovieAppService(IFilmesService filmesService)
        {
            this.filmesService = filmesService;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAll()
        {
            var movies = await filmesService.GetCurrentChampionship();

            if (movies == null)
                return new List<MovieViewModel>();

            return movies.Select(x => new MovieViewModel(x.Id, x.Title, x.Year, x.Score));
        }

    }
}
