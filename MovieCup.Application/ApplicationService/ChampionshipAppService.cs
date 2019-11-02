using MovieCup.Domain;
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
        private readonly IMovieAppService movieAppService;

        public ChampionshipAppService(IMovieAppService movieAppService)
        {
            this.movieAppService = movieAppService;
        }

        public async Task<ResultChampionshipCommand> Create(AddChampionshipCommand command)
        {
            await Validation(command);
            var result = StartChampionship(command.Movies);
            return result;
        }

        private ResultChampionshipCommand StartChampionship(List<AddMovieChampionshipCommand> movies)
        {
            var sortMovies = movies.OrderBy(x => x.Title)
                .Select(x => new Movie(x.Title, x.Score)).ToList();

            var rounds = CreateRounds(sortMovies);
            var totalRounds = (rounds.Count() - 1);

            for (int i = 0; i < totalRounds; i++)
            {
                rounds = GetRating(rounds);
            }

            var champion = rounds.First();

            return new ResultChampionshipCommand(champion.MovieOne.Title);
        }

        IEnumerable<Round> GetRating(IEnumerable<Round> rounds)
        {
            var ratings = new List<Movie>();
            foreach (var item in rounds)
            {
                if (item.MovieOne.Score > item.MovieTwo.Score)
                {
                    ratings.Add(item.MovieOne);
                }
                else if (item.MovieOne.Score < item.MovieTwo.Score)
                {
                    ratings.Add(item.MovieTwo);
                }
                else
                {
                    var classified = item.MovieOne.Title.CompareTo(item.MovieTwo.Title) < 0 ? item.MovieOne : item.MovieTwo;
                    ratings.Add(classified);
                }
            }

            var newRound = new List<Round>();
            if (ratings.Count > 1)
            {
                for (int i = 0; i < ratings.Count; i += 2)
                    newRound.Add(new Round(ratings[i], ratings[i + 1]));
            }
            else
            {
                newRound.Add(new Round(ratings.First(), null));
            }

            return newRound;
        }

        IEnumerable<Round> CreateRounds(List<Movie> moviesSelected)
        {
            int totalPositions = moviesSelected.Count() - 1;
            var rounds = moviesSelected
                .Take(moviesSelected.Count() / 2)
                .Select((movie, index) => new Round(movie, moviesSelected[totalPositions - index]));
            return rounds;
        }

        async Task Validation(AddChampionshipCommand command)
        {
            if (command is null)
                throw new ArgumentNullException(nameof(command));

            if (command.Movies.Count % 2 != 0)
                throw new ApplicationException(string.Format(ResourceMessage.InvalidCommand, "Movies"));

            var movies = await movieAppService.GetAll();
            if (!command.Movies.TrueForAll(x => movies.Select(e => e.Id).Contains(x.Id)))
                throw new ApplicationException(string.Format(ResourceMessage.NotExist, "Movies"));
        }
    }
}
