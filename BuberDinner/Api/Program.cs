using BuberDinner.Application;
using BuberDinner.Infrastrcuture;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services
            .AddApplication()
            .AddInfrastrcuture();
            
    builder.Services.AddControllers();
}


var app = builder.Build();
{

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

