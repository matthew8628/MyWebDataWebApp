var builder = WebApplication.CreateBuilder(args);



builder.Services.AddHttpClient();


// Add services
builder.Services.AddControllers();     // Enables API controllers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{

}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

// Maps attribute-routed controllers
app.MapControllers();

app.Run();
