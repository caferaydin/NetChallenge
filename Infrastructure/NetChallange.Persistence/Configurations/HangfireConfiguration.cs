using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.Persistence.Configurations
{
    public static class HangfireConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.GetSection(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/NetChallenge.API/"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("HangfireConnection");
            }
        }
    }
}
