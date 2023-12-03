using booksaw.api.Middlewares;
using booksaw.domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace booksaw.application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();
            return services;
        }
    }
}
