using BuberDinner.Application;
using BuberDinner.Infrastrcuture;
using DownTrack.Api;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services
            .AddPresentation()
            .AddApplication()
            .AddInfrastrcuture(builder.Configuration);
            
    builder.Services.AddControllers();
}


var app = builder.Build();
{

    

    app.UseHttpsRedirection();




    // nuevo agregado
    app.UseAuthentication();


    app.UseAuthorization();

    app.MapControllers();
    app.Run();
}

