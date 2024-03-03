using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Messenger.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomJwtAuthentication();
        }
    }
}
