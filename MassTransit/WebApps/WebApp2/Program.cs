using MassTransit;
using System.Reflection;
using WebApp2.Consumers;
using WebApp2.Context;
using WebApp2.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddMassTransit(c =>
{
    c.AddConsumers(Assembly.GetEntryAssembly());
    c.AddConsumer<UserConsumer>();
    c.UsingRabbitMq(
        (context, cfg) =>
        {
            cfg.ConfigureEndpoints(context);
        }
    );
    
});

builder.Services.AddScoped<UserManager>();
var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
