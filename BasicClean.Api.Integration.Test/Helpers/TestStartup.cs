using BasicClean.Api.Integration.Test.Setup;
using BasicClean.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicClean.Api.Integration.Test.Helpers
{
   public class TestStartup<TStartup> :WebApplicationFactory<TStartup> where TStartup:class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                //var options=DataMisalignedException
                services.AddDbContext<TodoDbContext>(options => options.UseInMemoryDatabase("testMemory"));

                var testDb = services.BuildServiceProvider().GetRequiredService<TodoDbContext>();
                testDb.Database.EnsureCreated();
                SeedData.Todos(testDb);
            });
            //base.ConfigureWebHost(builder);
        }
    }
}
