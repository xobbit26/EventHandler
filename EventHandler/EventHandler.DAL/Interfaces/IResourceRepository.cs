using EventHandler.DAL.Entities;
using System.Collections.Generic;

namespace EventHandler.DAL.Interfaces
{
    public interface IResourceRepository
    {
        IEnumerable<Resource> GetResources(string locale);
        Resource GetResourcesByIds(IEnumerable<string> ids, string locale);
    }
}
