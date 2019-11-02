using System.Threading.Tasks;
using MovieCup.Domain.Command.Championship;

namespace MovieCup.Domain.Interface.Application
{
    public interface IChampionshipAppService
    {
        Task<ResultChampionshipCommand> Create(AddChampionshipCommand command);
    }
}
