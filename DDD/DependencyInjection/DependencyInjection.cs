using Application.Services.PokemonsService;
using Domain.Bases;
using Domain.Entities;
using DTOs.Bases;
using DTOs.Dtos.Pokemon;
using DTOs.Dtos.Pokemon.Responses;
using Factory.ApiExternalFactory;
using Factory.MappersFactory;
using Factory.RepositorieFactory;
using Factory.RepositoryFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;
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
            
            services.AddTransient<IMapperFactory<BaseDomain, BaseRequest, ListPokemonsResponseDto>, MapperFactory<BaseDomain, BaseRequest, ListPokemonsResponseDto>>();
            services.AddTransient<IApiExternalFactory<ListPokemonsResponseDto>, ApiExternalFactory<ListPokemonsResponseDto>>();

            services.AddTransient<IMapperFactory<BaseDomain, BaseRequest, PokemonResponseDto>, MapperFactory<BaseDomain, BaseRequest, PokemonResponseDto>>();
            services.AddTransient<IApiExternalFactory<PokemonResponseDto>, ApiExternalFactory<PokemonResponseDto>>();

            services.AddTransient<IRepositoryFactory<Pokemon>, RepositoryFactory<Pokemon>>();
            services.AddTransient<IRepositoryFactory<Pokemons>, RepositoryFactory<Pokemons>>();

            //Application
            services.AddTransient<IPokemonsApiService, PokemonsApiService>();

            return services;
        }
    }
}
