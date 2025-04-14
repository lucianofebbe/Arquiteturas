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
            CreateMap<PokemonRequestDto, Pokemon>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));

            CreateMap<Pokemon, PokemonRequestDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Pokemon, PokemonResponseDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<PokemonResponseDto, Pokemon>();
        }
    }
}
