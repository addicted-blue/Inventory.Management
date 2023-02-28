using Inventory.Management.API.Services.Contracts;
using Inventory.Management.API.Services.Implementations;
using Serilog;

namespace Inventory.Management.API
{
    public static class StartUpHelper
    {
        internal static void SetUpApiLogging(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public static IServiceCollection RegisterCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
