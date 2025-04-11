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
        public Task<IMapper<Domain, Request, Response>> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
