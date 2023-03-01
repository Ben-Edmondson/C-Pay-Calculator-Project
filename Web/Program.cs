using PayCalc_Project.Models;
using PayCalc_Project.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<IEmployeeRepository<PermanentEmployee>, PermanentEmployeeRepo>();
builder.Services.AddSingleton<IEmployeeRepository<TemporaryEmployee>, TemporaryEmployeeRepo>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePagesWithRedirects("/Error/{0}");
    app.UseExceptionHandler("/Errors/NotFound");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
