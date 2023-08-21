using EfCore.Middlewares;
using Microsoft.EntityFrameworkCore;
using Registration;
using Shop.Core.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("ShopDb");

builder.Services.AddDbContext<RegDbContext>(option =>
{
    option.UseNpgsql(connectionString);
});

builder.Services.AddMyServices();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
