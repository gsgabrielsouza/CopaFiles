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
            IntegrationIoC(services);
            ApplicationIoC(services);

            return services;
        }

        private static void IntegrationIoC(IServiceCollection services) => 
            services.AddScoped<IFilmesService, FilmesService>();

        private static void ApplicationIoC(IServiceCollection services)
        {
            services.AddScoped<IMovieAppService, MovieAppService>();
            services.AddScoped<IChampionshipAppService, ChampionshipAppService>();
        }
    }
}
