using Microsoft.AspNetCore.Mvc;
using MovieCup.Domain.Command.Championship;
using MovieCup.Domain.Interface.Application;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MovieCup.API.Controller.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ChampionshipsController : ControllerBase
    {
        readonly IChampionshipAppService championshipAppService;

        public ChampionshipsController([NotNull] IChampionshipAppService championshipAppService) =>
            this.championshipAppService = championshipAppService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddChampionshipCommand command)
        {
            await championshipAppService.Create(command);
            return Ok();
        }
    }
}
