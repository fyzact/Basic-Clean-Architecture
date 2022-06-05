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
            services.AddDbContext<TodoDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped(typeof(ICommandRepository<,>), typeof(EFCommandRepository<,>));
            services.AddScoped(typeof(IQueryRepository<,>), typeof(EFQueryRepository<,>));
            //services.BuildServiceProvider().GetRequiredService<TodoDbContext>().Database.EnsureCreated();

            return services;
        }

    }
}
