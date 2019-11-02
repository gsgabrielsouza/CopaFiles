using MovieCup.Domain.ModelView.Movie;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCup.Domain.Interface.Application
{
    public interface IMovieAppService
    {
        Task<IEnumerable<MovieViewModel>> GetAll();
    }
}
