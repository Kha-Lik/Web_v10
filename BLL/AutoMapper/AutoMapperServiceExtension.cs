﻿using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.AutoMapper
{
    public static class AutoMapperServiceExtension
    {
        public static IServiceCollection BindMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutoMapperProfile()));

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}