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

        public Dictionary<string, string> GetResources(string locale)
        {
            return _resourceRepository.GetResources(locale)
                .ToDictionary(k => k.Id, v => v.Text);
        }

        public ResourceDTO GetResourcesByIds(IEnumerable<string> ids, string locale)
        {
            Resource resource = _resourceRepository.GetResourcesByIds(ids, locale);
            return new ResourceDTO(resource.Id, resource.Locale, resource.Text);
        }
    }
}
