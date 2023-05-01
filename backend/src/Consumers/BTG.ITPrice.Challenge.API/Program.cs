using Data;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:5173", "http://localhost:3000");
    });
});
// Add services to the container.
#region Setup Database
var server = builder.Configuration["DatabaseServer"] ?? "";
var port = builder.Configuration["DatabasePort"] ?? "";
var user = builder.Configuration["DatabaseUser"] ?? "";
var password = builder.Configuration["DatabasePassword"] ?? "";
var databaseName = builder.Configuration["DatabaseName"] ?? "";

var connectionString = builder.Configuration.GetConnectionString("Main");

if (!string.IsNullOrEmpty(server) &&
    !string.IsNullOrEmpty(port) &&
    !string.IsNullOrEmpty(user) &&
    !string.IsNullOrEmpty(password) &&
    !string.IsNullOrEmpty(databaseName))
{
    connectionString = $"Server={server};Database={databaseName};Port={port};User Id={user};Password={password}";
}
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseNpgsql(connectionString)
);
#endregion

#region Dependency Injection
//REFACT
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Make enums serialization better
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();



