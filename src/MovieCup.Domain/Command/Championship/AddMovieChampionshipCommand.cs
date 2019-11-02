namespace MovieCup.Domain.Command.Championship
{
    public class AddMovieChampionshipCommand
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public double Score { get; set; }
    }
}
