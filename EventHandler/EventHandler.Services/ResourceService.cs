using EventHandler.DAL.Interfaces;
using EventHandler.DTO;
using EventHandler.DTO.Enums;
using EventHandler.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.Services
{
    public class ResourceService : IResourceService
    {
        private static List<ResourceDTO> _resources;
        private static object _syncRoot = new object();

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

        public string GetTranslation(LocalizeKeysEnum key, string locale)
        {
            string _key = key.ToString("f");
            string resource = _resources?.FirstOrDefault(s => s.Id == _key && s.Locale == locale.ToUpperInvariant())?.Text;
            if (string.IsNullOrEmpty(resource))
            {
                lock (_syncRoot)
                {
                    if (string.IsNullOrEmpty(resource))
                        RefreshResources(locale);
                }
                resource = _resources.FirstOrDefault(s => s.Id == _key && s.Locale == locale.ToUpperInvariant())?.Text;
            }

            return resource;
        }

        private void RefreshResources(string locale)
        {
            _resources = _resourceRepository
                .GetResources(locale)
                .Select(s => new ResourceDTO(s.Id, s.Locale, s.Text))
                .ToList();
        }
    }
}
