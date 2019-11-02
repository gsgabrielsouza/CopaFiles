namespace MovieCup.Domain.Entitie
{
    public class Movie
    {
        public Movie(string title, double score)
        {
            Title = title;
            Score = score;
        }

        public string Title { get; }
        public double Score { get; }
    }
}
