namespace MovieCup.Domain.Command.Championship
{
    public class ResultChampionshipCommand
    {
        public ResultChampionshipCommand(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
