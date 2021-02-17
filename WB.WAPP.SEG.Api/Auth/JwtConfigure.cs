using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WB.WAPP.SEG
{
    public static class JwtConfigure
    {
        public static void ConfigureJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication("Oauth")
            .AddJwtBearer("Oauth", config =>
            {
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = JwtTokenDefinitions.IssuerSigningKey,
                    ValidIssuer = JwtTokenDefinitions.Issuer,
                    ValidAudience = JwtTokenDefinitions.Audience
                };
            });
        }
    }
}
