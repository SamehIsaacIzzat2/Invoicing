
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container
var assembly = typeof(Program).Assembly;

// Add CORS service to allow all origins
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssemblies(assembly);
    configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
    configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddDbContext<AppDbContext>(opts =>
        opts.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("Database")!);


var app = builder.Build();

//Configure the http request pipeline
app.UseExceptionHandler(opt => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.UseCors();

app.UseRouting();
app.MapControllers();

app.Run();
