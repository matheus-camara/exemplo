using Infra.Contexts;
using Infra.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Api.Configuration;

public static class Migrations
{
    public static void UseMigrations(this WebApplication? app)
    {
        using (var scope = app.Services.CreateScope())
        using (var context = scope.ServiceProvider.GetRequiredService<Context>())
        {
            if (context.Database.IsRelational() && context.Database.CanConnect())
            {
                context.Database.OpenConnection();
                context.ApplySeeds();
                context.Database.Migrate();
                context.Database.CloseConnection();
            }
        }
    }
}