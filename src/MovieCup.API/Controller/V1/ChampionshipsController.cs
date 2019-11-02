using Microsoft.AspNetCore.Mvc;
using MovieCup.Domain.Command.Championship;
using MovieCup.Domain.Interface.Application;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MovieCup.API.Controller.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ChampionshipsController : ControllerBase
    {
        readonly IChampionshipAppService championshipAppService;

        public ChampionshipsController(IChampionshipAppService championshipAppService) =>
            this.championshipAppService = championshipAppService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddChampionshipCommand command)
        {
            return Ok(await championshipAppService.Create(command));
        }
    }
}
