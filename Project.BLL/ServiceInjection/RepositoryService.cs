using Microsoft.Extensions.DependencyInjection;
using Project.DAL.Repositories.Abstracts;
using Project.DAL.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection
{
    public static class RepositoryService
    {
        public static void AddRepositoryServices(this IServiceCollection services)
        {
            //services.AddScoped<>

            /*
                Request => IOC 
            
            Deneme (ICategoryManager catMan1 , ICategoryManager catMan2)
            {
                Scoped = 1 Tane intance inject eder
                Transient = Kaç tane varsa o kadar inject eder
                Singleton = Zaten 1 tane inject eder ama o proje boyunca aynı instanceyi kaldırmaz
            }
             */

            services.AddScoped(typeof(IRepository<>) , typeof(BaseRepository<>));

            services.AddScoped<IAppUserRepository , AppUserRepository>();
            services.AddScoped<IAppUserProfileRepository , AppUserProfileRepository>();
            services.AddScoped<ICategoryRepository , CategoryRepository>();
            services.AddScoped<IProductRepository , ProductRepository>();
            services.AddScoped<IOrderRepository , OrderRepository>();
            services.AddScoped<IOrderDetailRepository , OrderDetailRepository>();
        }
    }
}
