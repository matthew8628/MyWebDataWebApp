using WebApi.Controllers;
using Services;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container (builder).
builder.Services.AddRazorPages(); // Enables razor pages
builder.Services.AddControllers();
builder.Services.AddHttpClient<UserService>(); // Register UserService with HttpClient

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages() 
   .WithStaticAssets();
app.MapControllers();


app.Run();