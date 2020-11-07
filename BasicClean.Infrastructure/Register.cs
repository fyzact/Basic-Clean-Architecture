using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BasicClean.Infrastructure
{
    public static class Register
    {
        public static  IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Todo");
            services.AddDbContextPool<TodoDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
