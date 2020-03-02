using EventHandler.DTO;
using EventHandler.DTO.Enums;
using System.Collections.Generic;

namespace EventHandler.Services.Interfaces
{
    public interface IResourceService
    {
        Dictionary<string, string> GetResources(string locale);
        string GetTranslation(LocalizeKeysEnum key, string locale);
    }
}
