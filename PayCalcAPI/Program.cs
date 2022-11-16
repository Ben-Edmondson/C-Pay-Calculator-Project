using PayCalc_Project.Repository;
using PayCalc_Project.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IEmployeeRepository<PermanentEmployee>, PermanentEmployeeRepo>();
builder.Services.AddSingleton<IEmployeeRepository<TemporaryEmployee>, TemporaryEmployeeRepo>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
