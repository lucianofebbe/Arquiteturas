using AutoMapper;
using Domain.Bases;
using DTOs.Bases;
using Interfaces.Factory.MappersFactory;
using Interfaces.Infrastructure.Mapper;
using System.Reflection;

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
                var mapper = new Mapper<Domain, Request, Response>(await LoadProfiles("Factory", "Factory.MappersFactory.Profiles"));
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

        private async Task<List<Profile>> LoadProfiles(string assemblyName, string namespaceFilter = null)
        {
            try
            {
                var assembly = AppDomain.CurrentDomain.GetAssemblies()
                      .FirstOrDefault(a => a.GetName().Name == assemblyName);

                if (assembly == null)
                    throw new Exception($"Assembly '{assemblyName}' não foi encontrado.");

                var profiles = assembly.GetTypes()
                    .Where(t => typeof(Profile).IsAssignableFrom(t)
                                && t.IsClass
                                && !t.IsAbstract
                                && (namespaceFilter == null || t.Namespace?.Contains(namespaceFilter) == true))
                    .Select(Activator.CreateInstance)
                    .Cast<Profile>()
                    .ToList();

                return profiles;
            }
            catch (Exception ex) { throw; }
        }
    }
}
