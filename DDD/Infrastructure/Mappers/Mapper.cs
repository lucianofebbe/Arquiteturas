﻿using AutoMapper;
using Azure.Core;
using Azure;
using Domain.Bases;
using DTOs.Bases;
using Interfaces.Factory.MappersFactory;
using Newtonsoft.Json;

namespace Interfaces.Infrastructure.Mapper
{
    public class Mapper<Domain, Request, Response> : IMapper<Domain, Request, Response>
        where Domain : BaseDomain
        where Request : BaseRequest
        where Response : BaseResponse
    {
        private readonly IMapper mapper;

        public Mapper(IEnumerable<Profile> profiles)
        {
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                    cfg.AddProfile(profile);

                cfg.CreateMap<Domain, BaseRequest>().ReverseMap();
                cfg.CreateMap<Domain, BaseResponse>().ReverseMap();
            });

            mapper = config.CreateMapper();
        }

        public Mapper(MapperConfiguration configuration)
        {
            mapper = configuration.CreateMapper();
        }

        public virtual async Task<string> DomainToJson(Domain item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<string> DomainToJson(List<Domain> item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Request> DomainToRequest(Domain item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Request>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Request>> DomainToRequest(List<Domain> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Request>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Response> DomainToResponse(Domain item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Response>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Response>> DomainToResponse(List<Domain> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Response>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Domain> JsonToDomain(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<Domain>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Domain>> JsonToDomainList(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Domain>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Request> JsonToRequest(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<Request>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Request>> JsonToRequestList(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Request>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Response> JsonToResponse(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<Response>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Response>> JsonToResponseList(string item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.DeserializeObject<List<Response>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Domain> RequestToDomain(Request item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Domain>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Domain>> RequestToDomain(List<Request> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Domain>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<string> RequestToJson(Request item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<string> RequestToJson(List<Request> item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Domain> ResponseToDomain(Response item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Domain>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Domain>> ResponseToDomain(List<Response> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Domain>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<string> ResponseToJson(Response item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<string> ResponseToJson(List<Response> item)
        {
            try
            {
                return await Task.FromResult(JsonConvert.SerializeObject(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Request> ResponseToRequest(Response item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Request>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Request>> ResponseToRequest(List<Response> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Request>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<Response> RequestToResponse(Request item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<Response>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<Response>> RequestToResponse(List<Request> item)
        {
            try
            {
                return await Task.FromResult(mapper.Map<List<Response>>(item));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private IMapper CreateMapper()
        {
            try
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Domain, Request>();
                    cfg.CreateMap<Request, Domain>();

                    cfg.CreateMap<Domain, Response>();
                    cfg.CreateMap<Response, Domain>();
                });

                return configuration.CreateMapper();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
