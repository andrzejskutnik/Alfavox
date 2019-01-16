using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alfavox
{
    public class Version
    {
  private readonly RequestDelegate _next;

        public Version(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Version-Service", typeof(Version).Assembly.GetName().Version.ToString());
            context.Response.Headers.Add("Owner-Service", "www.e-skutnik.eu");
            await _next(context);
        }
    }

}
