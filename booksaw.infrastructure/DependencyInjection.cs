using booksaw.domain.Interfaces;
using booksaw.infrastructure.Data;
using booksaw.infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace booksaw.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services)
        {
            services.AddSingleton<DbConnector>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
