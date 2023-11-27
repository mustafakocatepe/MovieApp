using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MovieStudyCase.Api.Middlewares;
using MovieStudyCase.DataAccess;
using MovieStudyCase.DataAccess.Context;
using MovieStudyCase.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MovieAppContext>(options => options.UseSqlServer("Server=.;Database=MovieApp;Trusted_Connection=True;"));


builder.Services.AddDataAccess(builder.Configuration);


builder.Services.AddServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Implement Swagger UI",
        Description = "A simple example to Implement Swagger UI",
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
