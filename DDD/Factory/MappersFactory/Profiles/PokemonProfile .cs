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
            CreateMap<Pokemon, PokemonResponseDto>()
                .ForMember(dest => dest.id, opt => opt.Ignore());

            CreateMap<Pokemon, PokemonRequestDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PokemonRequestDto, Pokemon>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PokemonRequestDto, PokemonResponseDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PokemonResponseDto, PokemonRequestDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.name));
        }
    }
}
