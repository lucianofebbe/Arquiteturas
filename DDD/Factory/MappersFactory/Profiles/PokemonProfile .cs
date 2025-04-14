using AutoMapper;
using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;

namespace Factory.MappersFactory.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            #region Pokemon
            CreateMap<PokemonRequestDto, Pokemon>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));

            CreateMap<Pokemon, PokemonRequestDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Pokemon, PokemonResponseDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());
            #endregion

            #region Pokemons
            CreateMap<PokemonRequestDto, Pokemons>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));

            CreateMap<Pokemons, PokemonRequestDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));
            #endregion
        }
    }
}
