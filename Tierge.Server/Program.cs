using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Tierge.Server.Data;
using Tierge.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load database connection settings from appsettings.json
var dbConfig = builder.Configuration
    .GetSection("Database")
    .Get<DatabaseSettings>()!;

// Add tierlist database context
builder.Services.AddDbContext<TierListDbContext>(options =>
{
    options.UseMongoDB(dbConfig.MongoDB, "tiergeDB");
});

// Add user/identity database context
builder.Services.AddDbContext<UserDbContext>(options =>
{
    options.UseNpgsql(dbConfig.PostgreSQL);
});

// Add Identity services
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<UserDbContext>();

// Allow access from web frontend
var appConfig = builder.Configuration
    .GetSection("App")
    .Get<Configuration>()!;

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(appConfig.FrontendOrigin);
    });
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.UseCors();

app.MapIdentityApi<ApplicationUser>();

/*var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<TierListDbContext>();
context.SaveChanges();*/

app.Run();