using Microsoft.Extensions.DependencyInjection;
using WB.WAPP.SEG.Business.Repositories;
using WB.WAPP.SEG.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WB.WAPP.SEG.Api.Ioc
{
    public static class IocServices
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
