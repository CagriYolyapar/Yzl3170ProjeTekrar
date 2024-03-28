using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.DAL.ContextClasses;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.ServiceInjection
{
    public static class CustomIdentityService
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole<int>>
                (
                  x =>
                  {
                      x.Password.RequireDigit = false;
                      x.Password.RequireUppercase = false;
                      x.Password.RequiredLength = 3;
                      x.Password.RequireLowercase = false;
                      x.Password.RequireNonAlphanumeric = false;
                      x.SignIn.RequireConfirmedEmail = true;
                      
                  }).AddEntityFrameworkStores<MyContext>();

            return services;
            
        }
    }
}
