using Application.Services.PokemonsService;
using Domain.Bases;
using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Facade.PokemonFacade;
using Factory.ApiExternalFactory;
using Factory.MappersFactory;
using Factory.MappersFactory.Profiles;
using Factory.RepositorieFactory;
using Factory.RepositoryFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Facade.PokemonFacade;
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
            #region ToApiExternalFactory
            services.AddSingleton<IUrlBuilder, PokemonUrlBuilder>();
            services.AddSingleton<IUrlBuilder, ListPkemonUrlBuilder>();
            #endregion

            #region ProfilesToMappersFactory
            services.AddAutoMapper(typeof(PokemonProfile));
            #endregion

            #region ToPokemonsService
            services.AddTransient<IApiExternalFactory<PokemonResponseDto>, ApiExternalFactory<PokemonResponseDto>>();
            services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>>();

            services.AddTransient<IApiExternalFactory<ListPokemonsResponseDto>, ApiExternalFactory<ListPokemonsResponseDto>>();
            services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>>();

            services.AddTransient<IRepositoryFactory<Pokemon>, RepositoryFactory<Pokemon>>();
            services.AddTransient<IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>, MapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>>();

            services.AddTransient<IRepositoryFactory<Pokemons>, RepositoryFactory<Pokemons>>();
            services.AddTransient<IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>>();

            services.AddTransient<IRepositoryFactory<PokemonColor>, RepositoryFactory<PokemonColor>>();
            services.AddTransient<IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto>, MapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto>>();
            #endregion

            #region Services
            services.AddTransient<IPokemonsApiService, PokemonsApiService>();
            services.AddTransient<IPokemonsRepoService, PokemonsRepoService>();
            #endregion

            #region Facade
            services.AddTransient<IPokemonFacade, PokemonFacade>();
            #endregion

            return services;
        }
    }
}
