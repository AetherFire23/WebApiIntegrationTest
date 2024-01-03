using Microsoft.EntityFrameworkCore;
using WebApplication1;

public class Program
{
    static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.ConfigureMyServices();

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var ctx = scope.ServiceProvider.GetRequiredService<MyContext>();
            ctx.Database.EnsureDeleted();
            ctx.Database.Migrate();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

}


public static class ServiceCollectionExtensions
{
    public static void ConfigureMyServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.ConfigureMyContext();
        serviceCollection.ConfigureServices();
    }
    public static void ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<MyRepository>();
        serviceCollection.AddScoped<MyOtherRepository>();
    }

    public static void ConfigureMyContext(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSqlServer<MyContext>("Server=localhost\\SQLEXPRESS01;Database=ProcedureContext;Trusted_Connection=True;TrustServerCertificate=True", opt =>
        {

        });
    }
}