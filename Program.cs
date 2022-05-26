using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SalePurchase.DbContexts;
using SalePurchase.IRepository;
using SalePurchase.Repository;

var builder = WebApplication.CreateBuilder(args);
var _env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var isDevelopment = _env == Environments.Development;
// Add services to the container.
var connectionString = string.Empty;
if (isDevelopment)
{
    connectionString = builder.Configuration.GetConnectionString("Development");
}
builder.Services.AddDbContext<ReadDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddDbContext<WriteDbContext>(options =>
options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPartner, PartnerConfig>();
builder.Services.AddTransient<IItem, ItemConfig>();
builder.Services.AddTransient<IPartnerTypee, PartnerTypeConfig>();

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
