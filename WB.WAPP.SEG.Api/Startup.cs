using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WB.WAPP.SEG.Api.Ioc;
using WB.WAPP.SEG.VModel.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using WB.WAPP.SEG.Model;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using WB.WAPP.SEG.Api.Swagger;

namespace WB.WAPP.SEG
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtTokenDefinitions.LoadFromConfiguration(Configuration);
            services.ConfigureJwtAuthentication();

            services.RegisterIoc();
            services.RegisterMapper(typeof(Startup));
            services.ConfigureSwagger();

            services.AddDbContext<SEGContext>(options => options.UseSqlServer(
                this.Configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection"),
                opt => opt.MigrationsHistoryTable("_MigrationsHistory", "BPM")
            ));

            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                 .RequireAuthenticatedUser()
                 .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string culture = Configuration.GetSection("Settings").GetValue<string>("CultureInfo");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture),
                SupportedCultures = new CultureInfo[] { new CultureInfo(culture) }
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.ConfigureSwagger();
        }
    }
}
