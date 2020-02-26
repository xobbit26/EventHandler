using EventHandler.DTO;
using System.Collections.Generic;

namespace EventHandler.Services.Interfaces
{
    public interface IResourceService
    {
        IEnumerable<ResourceDTO> GetResources(string locale);
        ResourceDTO GetResourcesByIds(IEnumerable<string> ids, string locale);
    }
}
