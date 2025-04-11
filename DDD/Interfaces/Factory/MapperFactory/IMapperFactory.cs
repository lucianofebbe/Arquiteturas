using Domain.Bases;
using DTOs.Bases;
using Interfaces.Infrastructure.Mapper;

namespace Interfaces.Factory.MappersFactory
{
    public interface IMapperFactory<Domain, Request, Response> 
        where Domain : BaseDomain
        where Request : BaseRequest
        where Response : BaseResponse
    {
        Task<IMapper<Domain, Request, Response>> CreateAsync();
    }
}
