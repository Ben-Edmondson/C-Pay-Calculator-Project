using PayCalc_Project.Models;
using log4net;
using System.Reflection;
using PayCalc_Class_Library.Repos.Repository;
using PayCalc_Class_Library.Repos;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
_log.Info("Hello there :)");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IEmployeeRepository<PermanentEmployee>, PermanentEmployeeRepo>();
builder.Services.AddSingleton<IEmployeeRepository<TemporaryEmployee>, TemporaryEmployeeRepo>();
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
