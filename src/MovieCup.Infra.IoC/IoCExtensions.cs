using Microsoft.Extensions.DependencyInjection;
using MovieCup.Application.ApplicationService;
using MovieCup.Domain.Interface.Application;
using MovieCup.Infra.Integration.Filmes.Interface;
using MovieCup.Infra.Integration.Filmes.Service;

namespace MovieCup.Infra.IoC
{
    public static class IoCExtensions
    {
        public static IServiceCollection AddIoC(this IServiceCollection services)
        {
            services.AddScoped<IFilmesService, FilmesService>();


            services.AddScoped<IMovieAppService, MovieAppService>();
            
            return services;
        }
    }
}
