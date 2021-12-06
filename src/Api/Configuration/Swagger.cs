using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Configuration
{
    public static class Swagger
    {
        public static void AddSwagger(this WebApplication? app)
        {
            app.UseSwagger(config =>
            {
                config.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                config.RoutePrefix = string.Empty;
            });
        }
    }
}