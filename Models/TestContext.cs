using Microsoft.EntityFrameworkCore;

namespace dotnet_webapi_template.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<TestModel> TestModels { get; set; }
    }
}