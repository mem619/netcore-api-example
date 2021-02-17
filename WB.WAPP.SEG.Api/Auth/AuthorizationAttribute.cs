using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WB.WAPP.SEG.Api.Auth
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        public AuthorizationAttribute()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers.Where(Auth => Auth.Key == "Authorization").FirstOrDefault();
            if (!Validation(token.Value))
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(new { 
                    success = false,
                    error = "Unauthorized"
                });
            }
        }

        private bool Validation(string token)
        {
            return !String.IsNullOrEmpty(token);
        }
    }
}
