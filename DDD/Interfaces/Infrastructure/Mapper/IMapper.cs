﻿using Domain.Bases;
using DTOs.Bases;

namespace Interfaces.Infrastructure.Mapper
{
    public interface IMapper<Domain, Request, Response>
     where Domain : BaseDomain
     where Request : BaseRequest
     where Response : BaseResponse
    {
        #region Domain and Request
        Task<Domain> RequestToDomain(Request item);
        Task<List<Domain>> RequestToDomain(List<Request> item);
        Task<Request> DomainToRequest(Domain item);
        Task<List<Request>> DomainToRequest(List<Domain> item);
        #endregion

        #region Domain and Response
        Task<Domain> ResponseToDomain(Response item);
        Task<List<Domain>> ResponseToDomain(List<Response> item);
        Task<Response> DomainToResponse(Domain item);
        Task<List<Response>> DomainToResponse(List<Domain> item);
        #endregion

        #region Request and Response
        Task<Request> ResponseToRequest(Response item);
        Task<List<Request>> ResponseToRequest(List<Response> item);
        Task<Response> RequestToResponse(Request item);
        Task<List<Response>> RequestToResponse(List<Request> item);
        #endregion

        #region JsonSerializer
        Task<string> DomainToJson(Domain item);
        Task<string> DomainToJson(List<Domain> item);
        Task<Domain> JsonToDomain(string item);
        Task<List<Domain>> JsonToDomainList(string item);

        Task<string> RequestToJson(Request item);
        Task<string> RequestToJson(List<Request> item);
        Task<Request> JsonToRequest(string item);
        Task<List<Request>> JsonToRequestList(string item);

        Task<string> ResponseToJson(Response item);
        Task<string> ResponseToJson(List<Response> item);
        Task<Response> JsonToResponse(string item);
        Task<List<Response>> JsonToResponseList(string item);
        #endregion
    
    }
}
