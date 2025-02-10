using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.ORM;

public class DefaultContext : DbContext
{

    //  add-migration -name versao_001 -StartupProject 'Ambev.DeveloperEvaluation.ORM'
    //  update-database -verbose -StartupProject 'Ambev.DeveloperEvaluation.ORM'

    public DbSet<User> Users { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
public class YourDbContextFactory : IDesignTimeDbContextFactory<DefaultContext>
{
    public DefaultContext CreateDbContext(string[] args)
    {
        //IConfigurationRoot configuration = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //    .Build();

        //var builder = new DbContextOptionsBuilder<DefaultContext>();

        //var connectionString = configuration.GetConnectionString("DefaultConnection");
        //builder.UseNpgsql(
        //       connectionString,
        //       b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
        //);

        //TODO: apenas para testes, remover depois
        var builder = new DbContextOptionsBuilder<DefaultContext>();
        var connectionString = @"Server=localhost;Port=5432;User id=developer;Password=ev@luAt10n;Database=developer_evaluation";
        builder.UseNpgsql(connectionString);


        return new DefaultContext(builder.Options);
    }
}