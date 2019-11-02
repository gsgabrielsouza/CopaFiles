namespace MovieCup.Domain.ModelView.Movie
{
    public class MovieViewModel
    {
        public MovieViewModel(string id, string title, int year, double score)
        {
            Id = id;
            Title = title;
            Year = year;
            Score = score;
        }

        public string Id { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public double Score { get; private set; }
    }
}
