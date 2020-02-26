using EventHandler.DAL.Entities;
using EventHandler.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventHandler.DAL.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly EventHandlerDbContext _dbContext;

        public ResourceRepository(EventHandlerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Resource> GetResources(string locale)
        {
            return _dbContext
                .Resources
                .Where(s => s.Locale == locale);
        }

        public Resource GetResourcesByIds(IEnumerable<string> ids, string locale)
        {
            return _dbContext
                .Resources
                .Where(x => ids.Contains(x.Id) && x.Locale == locale)
                .FirstOrDefault();
        }
    }
}
