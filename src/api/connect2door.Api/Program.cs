using Autofac;
using Autofac.Extensions.DependencyInjection;
using connect2door.Data;
using connect2door.Repository.AutofacModule;
using Microsoft.EntityFrameworkCore;
using connect2door.Repository.Interface;
using connect2door.Repository.Repository;
using connect2door.Api.Mapping;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(option => option.UseInMemoryDatabase("connect2door"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocument(x =>
{
    x.GenerateXmlObjects = true;
    x.GenerateEnumMappingDescription = true;
    x.DocumentName = "connect2door Shipment Api";
    x.Title = "connect2door Shipment";
    x.Description = "connect2door Shipment Api";
    
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        //builder.RegisterType(typeof(Repository<>)).As(typeof(IRepository<>));
        builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
        builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();


        builder.RegisterModule(new AutofacRepoModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
