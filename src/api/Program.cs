using System.Reflection;
using Api;
using Api.Exception;
using Application;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Validation.AspNetCore;
using Persistence;
using Polly;
using Polly.Extensions.Http;
using Serilog;
using ILogger = Serilog.ILogger;


var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddCommandLine(args)
    .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("connect2door");


builder.Services.AddSerilogLogger(config);
var logger = builder.Services.BuildServiceProvider().GetService<ILogger>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseOpenIddict();
});


// builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//     .AddEntityFrameworkStores<ApplicationDbContext>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// dependency dervices
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddDistributedMemoryCache();

builder.Services.AddApplication();

builder.Services.AddPersistence(config);
builder.Services.AddIdentity();
builder.Services.AddApiVersion();
builder.Services.AddDocSwagger();
builder.Services.AddSerilogLogger(config);
builder.Services.AddCors();
builder.Services.AddHttpClient("HttpClient").AddPolicyHandler(x =>
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .WaitAndRetryAsync(3, retry => TimeSpan.FromSeconds(Math.Pow(3, retry)));
});

//builder.Services.AddAuthorization();


var app = builder.Build();
// Configure the HTTP request pipeline.
app.UseCors(x =>
{
    x.WithOrigins("*");
    x.AllowAnyMethod();
    x.AllowAnyHeader();
});
    app.UseOpenApi();
    app.UseSwaggerUi3();
app.UseAuthentication();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
 }

app.ConfigureExceptionHandler(logger);
app.UseRouting();
app.UseAuthorization();
//app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
 {
      endpoints.MapControllers();
  });





// Logger section
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
app.ConfigureExceptionHandler(logger);

try
{
    logger.Information("Application Starting.");
    app.Run();
}
catch (System.Exception ex)
{
    logger.Fatal(ex, "The Application failed to start.");
}
finally
{
    Log.CloseAndFlush();
}

//==========
//app.Run();
