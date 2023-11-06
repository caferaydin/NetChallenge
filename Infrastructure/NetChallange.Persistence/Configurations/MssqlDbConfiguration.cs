using Microsoft.Extensions.Configuration;

namespace NetChallenge.Persistence.Configurations
{
    static class MssqlDbConfiguration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.GetSection(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/NetChallenge.API/"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SqlServer");
            }
        }
    }
}
