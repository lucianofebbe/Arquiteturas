using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.MappersFactory;
using Interfaces.Infrastructure.Repositories;

namespace Application.Services.PokemonsService
{
    public class PokemonsRepoService : IPokemonsRepoService
    {
        private IPokemonRepository<Pokemon> pokemonRepo;
        private IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto> facPokemonMapper;

        private IPokemonsRepository<Pokemons> pokemonsRepo;
        private IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto> facPokemonsMapper;

        private IPokemonColorRepository<PokemonColor> pokemonColorRepo;
        private IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto> facPokemonColorMapper;


        public PokemonsRepoService(
            IPokemonRepository<Pokemon> facPokemonRepo,
            IMapperFactory<Pokemon, PokemonRequestDto, PokemonResponseDto> facPokemonMapper,
            IPokemonsRepository<Pokemons> facPokemonsRepo,
            IMapperFactory<Pokemons, PokemonRequestDto, ListPokemonsResponseDto> facPokemonsMapper,
            IPokemonColorRepository<PokemonColor> facPokemonColorRepo,
            IMapperFactory<PokemonColor, PokemonRequestDto, PokemonResponseDto> facPokemonColorMapper)
        {
            this.pokemonRepo = facPokemonRepo;
            this.facPokemonMapper = facPokemonMapper;
            this.pokemonsRepo = facPokemonsRepo;
            this.facPokemonsMapper = facPokemonsMapper;
            this.pokemonColorRepo = facPokemonColorRepo;
            this.facPokemonColorMapper = facPokemonColorMapper;
        }

        #region Pokemon Tab
        public async Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var getRepoAsync = new Pokemon();
                if (!string.IsNullOrEmpty(request.Name))
                    getRepoAsync = await pokemonRepo.Get(o => o.Name == request.Name, cancellationToken);
                else
                    getRepoAsync = await pokemonRepo.Get(o => o.Guid == request.guid, cancellationToken);

                if (!string.IsNullOrEmpty(getRepoAsync.Name))
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
        
        public async Task<PokemonResponseDto> InsertPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var facMapper = await facPokemonMapper.CreateAsync();
                var addPokemon = await facMapper.RequestToDomain(request);
                var inserted = await pokemonRepo.Insert(addPokemon, cancellationToken);

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
                var facMapper = await facPokemonMapper.CreateAsync();

                var updated = await pokemonRepo.Update(await facMapper.RequestToDomain(request), cancellationToken);
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
            var result = new PokemonResponseDto();
            try
            {
                var facMapper = await facPokemonMapper.CreateAsync();
                var pokemonMapper = await facMapper.RequestToDomain(request);
                pokemonMapper.Deleted = true;
                var updated = await pokemonRepo.Update(pokemonMapper, cancellationToken);
                result = await facMapper.DomainToResponse(updated);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion

        #region Pokemons Tab
        public async Task<ListPokemonsResponseDto> GetPokemonsAsync(ListPokemonsRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var getRepoAsync = await pokemonsRepo.GetAll(cancellationToken, noTracking: true, skip: request.offset, take: request.limit);

                if (getRepoAsync.Count > 0)
                {
                    var facMapper = await facPokemonsMapper.CreateAsync();
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

        public async Task<ListPokemonsResponseDto> InsertPokemonsAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facMapper = await facPokemonsMapper.CreateAsync();
                var addPokemon = await facMapper.RequestToDomain(request);
                var inserted = await pokemonsRepo.Insert(addPokemon, cancellationToken);

                result = await facMapper.DomainToResponse(inserted);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ListPokemonsResponseDto> UpdatePokemonsAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facMapper = await facPokemonsMapper.CreateAsync();

                var updated = await pokemonsRepo.Update(await facMapper.RequestToDomain(request), cancellationToken);
                result = await facMapper.DomainToResponse(updated);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ListPokemonsResponseDto> DeletePokemonsAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facMapper = await facPokemonsMapper.CreateAsync();
                var pokemonRepo = await facMapper.RequestToDomain(request);
                pokemonRepo.Deleted = true;
                var updated = await pokemonsRepo.Update(pokemonRepo, cancellationToken);
                result = await facMapper.DomainToResponse(updated);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
        #endregion
    }
}
