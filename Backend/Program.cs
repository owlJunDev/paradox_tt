using Backend.Repositories;
using Backend.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<NoteRepository>();
builder.Services.AddSingleton<TagRepository>();
builder.Services.AddSingleton<AppDbContext>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Backend");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();