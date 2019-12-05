using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
           BuildWebHost(args).Run();
           
        }

        public static IWebHost BuildWebHost(string[] args){
           var host= WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()               
                .Build();
                using (var scope = host.Services.CreateScope())
                {
                    var initializer = scope.ServiceProvider.GetRequiredService<DataContext>();
                    initializer.Database.Migrate();
                }

                return host;
              
    }
    }
}
