using Microsoft.EntityFrameworkCore;
using Middlewear.DB.EF;
using Middlewear.DB.Services;
using Middlewear.Midleware;
using Middlewear.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EFcore>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Defualt"));
});

builder.Services.AddTransient<Crud>();
builder.Services.AddSingleton<IActiveHours, ActiveHours>();

var app = builder.Build();

app.UseMiddleware<AddRequest>();
app.UseMiddleware<TimeChecker>();

app.MapGet("/", () => "Hello world!");

app.Run();
