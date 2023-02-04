using System.Runtime.CompilerServices;

namespace CrudDemoApp.Utility
{
    public static class UtilityServiceCollectionExtensions
    {
        public static IServiceCollection AddUtilityConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            Helper.Loadconfigurations(configuration);
            return services;
        }
    }
}
