using Backend.Repositories;
using Backend.Contexts;
using Backend.Models;

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<NoteRepository>();
            builder.Services.AddScoped<TagRepository>();

            builder.Services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseNpgsql(configuration.GetConnectionString(nameof(AppDbContext)));
                });

            builder.Services.AddCors(options => options.AddPolicy(name: "MyCorsPolicy",
                policy =>
                {
                    policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                }));

            var modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntityType<Note>();
            modelBuilder.EntityType<Tag>();

            modelBuilder.EntitySet<Note>("Notes");
            modelBuilder.EntitySet<Tag>("Tags");

            builder.Services
                .AddControllers()
                .AddOData(options =>
                    options
                        .Select()
                        .Expand()
                        .Filter()
                        .Count()
                        .OrderBy()
                        .SetMaxTop(100)
                        .EnableQueryFeatures()
                        .AddRouteComponents(
                            routePrefix: "odata",
                            model: modelBuilder.GetEdmModel()));

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseStaticFiles();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }

            app.UseCors("MyCorsPolicy");
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}