using BLL.AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BllServices
    {
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddTransient<IOrderService, OrderService>()
                .AddTransient<IOwnerService, OwnerService>()
                .AddTransient<IPartService, PartService>()
                .AddTransient<IUserService, UserService>()
                .BindMapper();
            return services;
        }
    }
}