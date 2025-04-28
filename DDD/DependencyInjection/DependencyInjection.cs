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
        private static IConfiguration _configuration;
        private static IServiceCollection _services;

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            AddRepository();
            AddApiExternal();
            AddDependenciesPokemonsServices();
            AddPokemonsServices();
            AddFacade();

            return services;
        }

        private static IServiceCollection AddRepository()
        {
            _services.AddDbContext<Context>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            _services.AddScoped(typeof(IPokemonRepository<>), typeof(PokemonRepository<>));
            _services.AddScoped(typeof(IPokemonsRepository<>), typeof(PokemonsRepository<>));
            _services.AddScoped(typeof(IPokemonColorRepository<>), typeof(PokemonColorRepository<>));
            return _services;
        }

        private static IServiceCollection AddApiExternal()
        {
            _services.AddSingleton<PokemonUrlBuilder>();
            _services.AddSingleton<ListPokemonUrlBuilder>();
            return _services;
        }

        private static IServiceCollection AddDependenciesPokemonsServices()
        {
            _services.AddTransient<IUrlBuilder, PokemonUrlBuilder>();
            _services.AddTransient<IUrlBuilder, ListPokemonUrlBuilder>();
            _services.AddTransient<IApiExternalFactory<PokemonResponseDto>, ApiExternalFactory<PokemonResponseDto>>();
            _services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto>>();
            _services.AddTransient<IApiExternalFactory<ListPokemonsResponseDto>, ApiExternalFactory<ListPokemonsResponseDto>>();
            _services.AddTransient<IMapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto>>();
            _services.AddTransient<IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>, MapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto>>();
            _services.AddTransient<IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>, MapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto>>();
            _services.AddTransient<IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto>, MapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto>>();
            return _services;
        }

        private static IServiceCollection AddPokemonsServices()
        {
            _services.AddTransient<IPokemonsApiService, PokemonsApiService>();
            _services.AddTransient<IPokemonsRepoService, PokemonsRepoService>();
            return _services;
        }

        private static IServiceCollection AddFacade()
        {
            _services.AddTransient<IPokemonFacade, PokemonFacade>();
            return _services;
        }
    }
}
