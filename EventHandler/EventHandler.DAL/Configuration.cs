using Microsoft.Extensions.Configuration;
using System.IO;

namespace EventHandler.DAL
{
    class Configuration
    {
        private readonly string _sqlConnectionString;

        public Configuration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _sqlConnectionString = root.GetConnectionString("DataConnection");
        }

        public string SqlConnectionString { get => _sqlConnectionString; }
    }
}
