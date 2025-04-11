using AutoMapper;
using Domain.Bases;
using DTOs.Bases;
using Interfaces.Factory.MappersFactory;
using Interfaces.Infrastructure.Mapper;

namespace Factory.MappersFactory
{
    public class MapperFactory<Domain, Request, Response> : IMapperFactory<Domain, Request, Response>
        where Domain : BaseDomain
        where Request : BaseRequest
        where Response : BaseResponse
    {
        public async Task<IMapper<Domain, Request, Response>> CreateAsync()
        {
            try
            {
                var mapper = new Mapper<Domain, Request, Response>();
                return mapper;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<IMapper<Domain, Request, Response>> CreateAsync(MapperConfiguration configuration)
        {
            try
            {
                var mapper = new Mapper<Domain, Request, Response>(configuration);
                return mapper;
            }
            catch (Exception ex) { throw; }

        }
    }
}
