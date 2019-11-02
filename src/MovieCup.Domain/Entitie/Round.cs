namespace MovieCup.Domain.Entitie
{
    public class Round
    {
        public Round(Movie movieOne, Movie movieTwo)
        {
            MovieOne = movieOne;
            MovieTwo = movieTwo;
        }

        public Movie MovieOne { get; }
        public Movie MovieTwo { get; }
    }
}
