using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseIdentityColumns();
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Context))!, x => !x.IsAbstract);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries())
            if (entry is { State: EntityState.Added or EntityState.Modified, Entity: Auditable auditable })
                auditable.Modified = DateTime.UtcNow;

        return base.SaveChangesAsync(cancellationToken);
    }
}