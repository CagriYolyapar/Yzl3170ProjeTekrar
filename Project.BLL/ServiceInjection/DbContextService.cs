using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Project.DAL.ContextClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection
{
    public static class DbContextService
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services)
        {
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            IConfiguration configuration = serviceProvider.GetService<IConfiguration>();

            services.AddDbContextPool<MyContext>(options => options.UseSqlServer(configuration.GetConnectionString("MetinConnection")).UseLazyLoadingProxies());

            return services;
        } 
    }
}
