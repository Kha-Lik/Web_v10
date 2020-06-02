using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalServices
    {
        public static IServiceCollection AddDalServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ComputerWorkshopContext>(builder =>
                builder.UseSqlServer(connectionString));
            services.AddScoped(typeof(IRepository<>), 
                    typeof(Repository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddIdentity<User, IdentityRole>(opt =>
                {
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireNonAlphanumeric = false;
                    opt.Password.RequiredLength = 4;
                    opt.Password.RequireDigit = false;
                    opt.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<ComputerWorkshopContext>();
            return services;
        }
    }
}