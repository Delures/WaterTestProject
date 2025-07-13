using System.IO;
using Microsoft.Extensions.Configuration;

namespace WaterTestProject;

public static class ConfigurationLoader
{
    public static IConfiguration Load()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .Build();
    }
}