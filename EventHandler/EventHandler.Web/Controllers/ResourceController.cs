using System;
using System.Collections.Generic;
using EventHandler.DTO;
using EventHandler.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventHandler.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;
        IResourceService _resourceService;

        public ResourceController(IResourceService resourceService, ILogger<ResourceController> logger)
        {
            _resourceService = resourceService;
            _logger = logger;
        }

        [HttpGet]
        [Route("{lang}/translations.json")]
        public Dictionary<string, string> Get(string lang)
        {
            try
            {
                return _resourceService.GetResources(lang);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }
    }
}