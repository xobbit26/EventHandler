using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public IEnumerable<ResourceDTO> GetResources(string locale)
        {
            return _resourceRepository.GetResources(locale)
                .Select(x=> new ResourceDTO(x.Id, x.Locale, x.Text));
        }

        public ResourceDTO GetResourcesByIds(IEnumerable<string> ids, string locale)
        {
            Resource resource = _resourceRepository.GetResourcesByIds(ids, locale);
            return new ResourceDTO(resource.Id, resource.Locale, resource.Text);
        }
    }
}
