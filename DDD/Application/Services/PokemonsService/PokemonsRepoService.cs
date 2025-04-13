using AutoMapper;
using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Factory.RepositoryFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.MappersFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsRepoService : IPokemonsRepoService
    {
        private IRepositoryFactory<Pokemon> facPokemonRepo;
        private IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto> facPokemonMapper;

        private IRepositoryFactory<Pokemons> facPokemonsRepo;
        private IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto> facPokemonsMapper;

        private IRepositoryFactory<PokemonColor> facPokemonColorRepo;
        private IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto> facPokemonColorMapper;


        public PokemonsRepoService(
            IRepositoryFactory<Pokemon> facPokemonRepo,
            IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto> facPokemonMapper,
            IRepositoryFactory<Pokemons> facPokemonsRepo,
            IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto> facPokemonsMapper,
            IRepositoryFactory<PokemonColor> facPokemonColorRepo,
            IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto> facPokemonColorMapper)
        {
            this.facPokemonRepo = facPokemonRepo;
            this.facPokemonMapper = facPokemonMapper;
            this.facPokemonsRepo = facPokemonsRepo;
            this.facPokemonsMapper = facPokemonsMapper;
            this.facPokemonColorRepo = facPokemonColorRepo;
            this.facPokemonColorMapper = facPokemonColorMapper;
        }

        public async Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var facPokemon = await facPokemonRepo.CreateAsync();
                var getRepoAsync = await facPokemon.Get(o => o.Name == request.name, cancellationToken);

                if (getRepoAsync != null)
                {
                    var facMapper = await facPokemonMapper.CreateAsync();
                    var mapper = await facMapper.DomainToResponse(getRepoAsync);
                    result = mapper;
                }
                else
                    result.Message = "Pokemon not found";

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ListPokemonsResponseDto> GetPokemonsAsync(ListPokemonsRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facPokemons = await facPokemonsRepo.CreateAsync();
                var getRepoAsync = await facPokemons.GetAll(cancellationToken, skip: request.offset, take: request.limit);

                if (getRepoAsync.Count > 0)
                {
                    var configMapper = new MapperConfiguration(config =>
                    {
                        config.CreateMap<Pokemons, ItemPokemonsResultDto>()
                        .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url));
                    });

                    var facMapper = await facPokemonsMapper.CreateAsync(configMapper);
                    var mapper = await facMapper.DomainToResponse(getRepoAsync);
                    result.Results.AddRange(mapper.FirstOrDefault().Results);
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<PokemonResponseDto> InsertPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var facPokemon = await facPokemonRepo.CreateAsync();
                var facMapper = await facPokemonMapper.CreateAsync();

                var inserted = await facPokemon.Insert(await facMapper.RequestToDomain(request), cancellationToken);
                result = await facMapper.DomainToResponse(inserted);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<PokemonResponseDto> UpdatePokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var facPokemon = await facPokemonRepo.CreateAsync();
                var facMapper = await facPokemonMapper.CreateAsync();

                var updated = await facPokemon.Update(await facMapper.RequestToDomain(request), cancellationToken);
                result = await facMapper.DomainToResponse(updated);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<PokemonResponseDto> DeletePokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
