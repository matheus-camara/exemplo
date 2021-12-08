using Infra.Contexts;
using Infra.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Core.Tests.Contexts;

public class TestContext : Context
{
    public TestContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        this.ApplySeeds();
    }
}