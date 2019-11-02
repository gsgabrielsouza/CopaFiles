using Microsoft.AspNetCore.Mvc;
using MovieCup.Domain.Interface.Application;
using System;
using System.Threading.Tasks;

namespace MovieCup.API.Controller.V1
{
    [ApiController]
    [Route("v1/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieAppService appService;

        public MoviesController(IMovieAppService appService) =>
            this.appService = appService ?? throw new NullReferenceException(nameof(appService));

        [HttpGet]
        public async Task<IActionResult> Get() =>
             Ok(await appService.GetAll());


    }
}
