using Microsoft.EntityFrameworkCore;
using si730ebu2019126668.API.Inventory.Application.ACL;
using si730ebu2019126668.API.Inventory.Application.Internal.CommandServices;
using si730ebu2019126668.API.Inventory.Application.Internal.QueryServices;
using si730ebu2019126668.API.Inventory.Domain.Repositories;
using si730ebu2019126668.API.Inventory.Domain.Services;
using si730ebu2019126668.API.Inventory.Infrastructure.Persistence.EFC.Repositories;
using si730ebu2019126668.API.Inventory.Interfaces.ACL;
using si730ebu2019126668.API.Observability.Application.Internal.CommandServices;
using si730ebu2019126668.API.Observability.Application.Internal.OutboundServices.ACL;
using si730ebu2019126668.API.Observability.Domain.Repositories;
using si730ebu2019126668.API.Observability.Domain.Services;
using si730ebu2019126668.API.Observability.Infrastructure.Persistence.EFC.Repositories;
using si730ebu2019126668.API.Shared.Domain.Repositories;
using si730ebu2019126668.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu2019126668.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (connectionString is null)
    throw new Exception("Database connection is not set.");

if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableDetailedErrors();
    });

// Configure Dependency Injection

//Shared BC
builder.Services.AddScoped<IUnitOfWOrk, UnitOfWork>();

//Inventory BC
builder.Services.AddScoped<IThingRepository, ThingRepository>();
builder.Services.AddScoped<IThingQueryService, ThingQueryService>();
builder.Services.AddScoped<IThingCommandService, ThingCommandService>();
builder.Services.AddScoped<IInventoryContextFacade, InventoryContextFacade>();

//Observability BC
builder.Services.AddScoped<IThingStateRepository, ThingStateRepository>();
builder.Services.AddScoped<IThingStateCommandService, ThingStateCommandService>();
builder.Services.AddScoped<ExternalInventoryService, ExternalInventoryService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
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