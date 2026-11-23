using Step4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddScoped<UsersService>();    // new UserService()


var app = builder.Build();

app.MapControllers();

app.Run();
