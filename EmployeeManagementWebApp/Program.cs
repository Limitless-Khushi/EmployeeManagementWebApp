using Microsoft.EntityFrameworkCore;
using EmployeeManagementWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add MVC Services to the container
builder.Services.AddControllersWithViews();

// Register the Database Context with SQL Server local database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// CHANGED: Redirects the default route immediately to our advanced Employees dashboard
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();