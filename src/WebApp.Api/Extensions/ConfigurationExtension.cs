namespace WebApp.Api.Extensions
{
    public static class ConfigurationExtension
    {
        internal static IConfiguration AddConfiguration()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            return new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                            .Build();
        }
    }
}