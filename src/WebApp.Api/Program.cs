using WebApp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = ConfigurationExtension.AddConfiguration();

builder.Services.AddControllers();
builder.Services.AddDbContext(configuration);
builder.Services.AddDependencyResolvers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddJsonConsole();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
