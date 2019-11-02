using MovieCup.Infra.Integration.Filmes.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCup.Infra.Integration.Filmes.Interface
{
    public interface IFilmesService
    {
        Task<IEnumerable<FilmesResponse>> GetCurrentChampionship();
    }
}
