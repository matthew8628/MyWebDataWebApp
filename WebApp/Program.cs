using Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DataAccess;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container (builder).
builder.Services.AddRazorPages(); // Enables razor pages

builder.Services.AddHttpClient();


builder.Services.AddDbContext<WebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppContext") ?? throw new InvalidOperationException("Connection string 'WebAppContext' not found.")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddHttpClient<IUserService, UserService>();


builder.Services.AddControllers();


var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Urls.Add("https://localhost:5000"); // Listen on port 5000

// Middleware configuration
app.UseHttpsRedirection();  // Redirect HTTP to HTTPS
app.UseRouting();
app.UseAuthorization();


app.UseStaticFiles();



app.MapRazorPages();
app.MapControllers();

app.Run();