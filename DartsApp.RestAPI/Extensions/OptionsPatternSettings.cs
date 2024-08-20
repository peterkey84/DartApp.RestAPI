using DartsApp.RestAPI.Settings;

namespace DartsApp.RestAPI.Extensions
{
    public static class OptionsPatternSettings
    {

        public static void AddOptionsPatternSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BoardSettings>(configuration.GetSection(nameof(BoardSettings)));
            services.Configure<BoardLimits>(configuration.GetSection(nameof(BoardLimits)));
            services.Configure<PlayerSettings>(configuration.GetSection(nameof(PlayerSettings)));
            services.Configure<PlayerValidation>(configuration.GetSection(nameof(PlayerValidation)));
        }
    }
}
