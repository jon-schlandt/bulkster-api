using Bulkster_API.Data;
using Bulkster_API.Repositories.Implementations;
using Bulkster_API.Repositories.Interfaces;
using Bulkster_API.Security;
using Bulkster_API.Services.Implementations;
using Bulkster_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BulksterDbContext>((options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("BulksterDb");
    var serverVersion = ServerVersion.Create(new Version("8.0"), ServerType.MySql);

    options.UseMySql(connectionString, serverVersion);
});

// Register services
builder.Services.AddScoped<IAuthUserService, AuthUserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientOptionsService, ClientOptionsService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IProgressService, ProgressService>();

// Register repositories
builder.Services.AddScoped<IActivityLevelRepository, ActivityLevelRepository>();
builder.Services.AddScoped<IAuthUserRepository, AuthUserRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IProgressLogRepository, ProgressLogRepository>();

// Register DB contexts
builder.Services.AddScoped<IBulksterDbContext, BulksterDbContext>();

// Register validation
builder.Services.AddScoped<ApiKeyAuthFilter>();
builder.Services.AddTransient<IApiKeyValidator, ApiKeyValidator>();

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
