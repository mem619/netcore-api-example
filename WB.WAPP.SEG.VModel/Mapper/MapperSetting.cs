using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WB.WAPP.SEG.VModel.Mapper
{
    public static class Mapper
    {
        public static void RegisterMapper(this IServiceCollection services, Type startup)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Mapping());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(startup);
        }
    }
}
