using MovieCup.Domain.Command.Championship;
using MovieCup.Domain.Entitie;
using MovieCup.Domain.Interface.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCup.Application.ApplicationService
{
    public class ChampionshipAppService : IChampionshipAppService
    {
        public async Task<ResultChampionshipCommand> Create(AddChampionshipCommand command)
        {
            var result = await StartChampionship(command.Movies);
            return result;
        }

        private async Task<ResultChampionshipCommand> StartChampionship(List<AddMovieChampionshipCommand> movies)
        {
            var sortMovies = movies.OrderBy(x => x.Title);

            var rounds = CreateRounds(sortMovies.Select(x => new Movie(x.Title, x.Score)));
            var totalRounds = (rounds.Count() - 1);

            for (int i = 0; i < totalRounds; i++)
            {
                var rank = GetRating(rounds);
                rounds = CreateRounds(rank).ToList();
                if (rounds.Count() == 1)
                {
                    var champion = GetRating(rounds).First();
                    return new ResultChampionshipCommand(champion.Title);
                }
            }

            return new ResultChampionshipCommand();
        }

        IEnumerable<Movie> GetRating(IEnumerable<Round> rounds)
        {
            foreach (var item in rounds)
            {
                if (item.MovieOne.Score > item.MovieTwo.Score)
                {
                    yield return item.MovieOne;
                }
                else if (item.MovieOne.Score < item.MovieTwo.Score)
                {
                    yield return item.MovieTwo;
                }
                else
                {
                    yield return item.MovieOne.Title.CompareTo(item.MovieTwo.Title) < 0 ? item.MovieOne : item.MovieTwo;
                }
            }
        }

        IEnumerable<Round> CreateRounds(IEnumerable<Movie> moviesSelected)
        {
            int totalElements = moviesSelected.Count();
            var reverse = moviesSelected.OrderByDescending(x => x.Title)
                    .Take(totalElements / 2).ToArray();

            return moviesSelected
                .Take(totalElements / 2)
                .Select((movie, i) =>
                    new Round(
                        movie,
                        reverse[i])
                    );
        }



        private void Validation(AddChampionshipCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
