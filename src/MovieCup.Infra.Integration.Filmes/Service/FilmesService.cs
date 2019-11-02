using Flurl.Http;
using MovieCup.Infra.Integration.Filmes.Interface;
using MovieCup.Infra.Integration.Filmes.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCup.Infra.Integration.Filmes.Service
{
    public class FilmesService : IFilmesService
    {
        const string baseUrl = "http://copafilmes.azurewebsites.net/api";

        public async Task<IEnumerable<FilmesResponse>> GetCurrentChampionship()
        {
            var movies = await $"{baseUrl}/filmes"
                .GetJsonAsync<IEnumerable<FilmesResponse>>();

            return movies;
        }
    }
}
