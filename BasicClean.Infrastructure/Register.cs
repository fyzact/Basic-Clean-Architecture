using BasicClean.Core.Interfaces.Repositories;
using BasicClean.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace BasicClean.Infrastructure
{
    public static class Register
    {
        public static  IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("TodoDb");
            services.AddDbContextPool<TodoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(ICommandRepository<,>), typeof(EFCommandRepository<,>));
            return services;
        }
    }
}
