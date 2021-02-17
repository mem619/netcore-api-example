using Microsoft.Extensions.DependencyInjection;
using WB.WAPP.SEG.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WB.WAPP.SEG.Api.Ioc
{
    public static class IocBussines
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<ISampleBusiness, SampleBusiness>();
            services.AddScoped<IParameterBusiness, ParameterBusiness>();
        }
    }
}
