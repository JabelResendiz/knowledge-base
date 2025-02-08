

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Set;
var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;

// Add controllers to handle API requests
services.AddControllers();

// Add Swagger for API documentation
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Configure CORS to allow any origin, method, and headers
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin() // allows requests from any origin
               .AllowAnyHeader() // allows HTTP headers
               .AllowAnyMethod(); // allows any HTTP method (GET,POST,PUT,DELETE)
    });
});

var connectionString = configuration.GetConnectionString("AppDbConnectionString");
var db = services.AddDbContext<DownTrackContext>(options => options.UseMySql(
                                                connectionString, ServerVersion.AutoDetect(connectionString)));

// Add HttpContextAccessor for accessing the current HTTP context
services.AddHttpContextAccessor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();
//app.UseCors("LocalhostPolicy");
        
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

