using System.Reflection;
using MassTransit;
using Price.Api.Managers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(c =>
{
    c.AddConsumers(Assembly.GetEntryAssembly());

    c.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});


builder.Services.AddScoped<IPriceManager, PriceManager>();

var app = builder.Build();


app.Run();
