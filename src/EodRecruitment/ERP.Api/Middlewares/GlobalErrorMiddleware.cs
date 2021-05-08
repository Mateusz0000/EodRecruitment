using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ERP.Api.Middlewares
{
    public class GlobalErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;

                switch (ex)
                {
                    case ApplicationException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(ex?.Message);
                await response.WriteAsync(result);
            }
        }
    }
}
