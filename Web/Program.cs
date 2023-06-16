using PayCalc_Class_Library.Persistent_Repository;
using PayCalc_Class_Library.Repos;
using PayCalc_Class_Library.Repos.Repository;
using PayCalc_Project.Models;
using PayCalc_Project.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

/*builder.Services.AddSingleton<IEmployeeRepository<PermanentEmployee>, PermanentEmployeeRepo>();
builder.Services.AddSingleton<IEmployeeRepository<TemporaryEmployee>, TemporaryEmployeeRepo>();*/
builder.Services.AddDbContext<MyDbContext>();

builder.Services.AddScoped<IEmployeeRepository<PermanentEmployee>, PersistentPermanentEmployeeRepo>();
builder.Services.AddScoped<IEmployeeRepository<TemporaryEmployee>, PersistentTemporaryEmployeeRepo>();

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/NotFound");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error/Error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
