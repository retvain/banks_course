using Microsoft.Extensions.Configuration;

namespace banks_course
{
    public static class Settings
    {
        private static readonly Lazy<IConfigurationSection> CachedSettings = new Lazy<IConfigurationSection>(LoadSettings);

        private static IConfigurationSection LoadSettings()
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var rootSection = config.GetRequiredSection("ExchangeRateSettings");

            return rootSection;
        }

        public static IConfigurationSection GetSection(string key)
        {
            return CachedSettings.Value.GetSection(key);
        }
    }
}