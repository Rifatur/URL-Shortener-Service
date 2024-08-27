using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UrlShortenerService.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
