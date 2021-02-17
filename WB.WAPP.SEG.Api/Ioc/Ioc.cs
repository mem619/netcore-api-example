using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WB.WAPP.SEG.Api.Ioc
{
    public static class Ioc
    {
        public static void RegisterIoc(this IServiceCollection services)
        {
            IocServices.Register(services);
            IocBussines.Register(services);
        }
    }
}

