using Microsoft.EntityFrameworkCore;
using Multi_Page_WebApp_Contacts.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add EF Core dependency injection using the AddDbContext(), containing the DB server and connection string to use.
// Notice "ContactContext" matches in appsettings.json connection string ID.
// EnableSensitiveDataLogging and log level is specified to help with debugging.
builder.Services.AddDbContext<ContactContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext")).EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));

// Making URLS lowercase and ending with a slash for user friendliness.
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true; options.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
