using System.Collections.Generic;
using EventHandler.DTO;
using EventHandler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventHandler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet]
        public IEnumerable<ResourceDTO> Get(string locale)
        {
            return _resourceService.GetResources(locale);
        }
    }
}