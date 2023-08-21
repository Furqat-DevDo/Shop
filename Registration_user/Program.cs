
using Registration_user.Entities;
using Registration_user.Services;
using Registration_user.Services.Interfaces;
using Registration_user;
using Registration_user.Data;
using Microsoft.EntityFrameworkCore;
using Registration_user.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PasswordEncryptDecryptHelper>();
builder.Services.AddScoped<IUserService, UserService>();

var connectionString = builder.Configuration.GetConnectionString("UserDb");

builder.Services.AddDbContext<UserDbContext>(option =>
{
    option.UseNpgsql(connectionString);
});

var app = builder.Build();

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
