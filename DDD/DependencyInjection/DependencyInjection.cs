using Application.Services.PokemonsService;
using Domain.Entities;
using DTOs.Dtos;
using Factory.ApiExternalFactory;
using Factory.RepositorieFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //Factory
            services.AddTransient<IApiExternalFactory<Pokemon>, ApiExternalFactory<Pokemon>>();
            services.AddTransient<IApiExternalFactory<PokemonListDto>, ApiExternalFactory<PokemonListDto>>();
            
            services.AddTransient<IRepositorieFactory<Pokemon>, RepositorieFactory<Pokemon>>();
            services.AddTransient<IRepositorieFactory<Pokemons>, RepositorieFactory<Pokemons>>();

            //Application
            services.AddTransient<IPokemonsService, PokemonsService>();

            return services;
        }
    }
}
