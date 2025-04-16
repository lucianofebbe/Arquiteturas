using Application.Services.PokemonsService;
using Domain.Bases;
using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Facade.PokemonFacade;
using Factory.ApiExternalFactory;
using Factory.MappersFactory;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Facade.PokemonFacade;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;
using Interfaces.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
            options.UseSqlServer("DefaultConnection"));

            #region ToApiExternalFactory
            services.AddSingleton<IUrlBuilder, PokemonUrlBuilder>();
            services.AddSingleton<IUrlBuilder, ListPkemonUrlBuilder>();
            #endregion

            #region ToPokemonsService
            services.AddTransient<IApiExternalFactory<PokemonResponseDto>, ApiExternalFactory<PokemonResponseDto>>();
            services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>>();

            services.AddTransient<IApiExternalFactory<ListPokemonsResponseDto>, ApiExternalFactory<ListPokemonsResponseDto>>();
            services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>>();

            services.AddTransient<IPokemonRepository<Pokemon>, PokemonRepository<Pokemon>>();
            services.AddTransient<IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>, MapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>>();

            services.AddTransient<IPokemonsRepository<Pokemons>, PokemonsRepository<Pokemons>>();
            services.AddTransient<IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>>();

            services.AddTransient<IPokemonColorRepository<PokemonColor>, PokemonColorRepository<PokemonColor>>();
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
