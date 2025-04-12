using Application.Services.PokemonsService;
using Domain.Bases;
using Domain.Entities;
using DTOs.Bases;
using DTOs.Dtos.Pokemon;
using Factory.ApiExternalFactory;
using Factory.MappersFactory;
using Factory.RepositorieFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;
using Interfaces.Infrastructure.Mapper;
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

            services.AddTransient<IRepositorieFactory<Pokemon>, RepositorieFactory<Pokemon>>();
            services.AddTransient<IRepositorieFactory<Pokemons>, RepositorieFactory<Pokemons>>();

            //Application
            services.AddTransient<IPokemonsService, PokemonsService>();

            return services;
        }
    }
}
