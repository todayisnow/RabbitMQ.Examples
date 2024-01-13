using MassTransit;
using RabbitMQ.MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.AutoDelete = true;
        cfg.Durable = false;



        cfg.ConfigureEndpoints(context);
    });

    x.AddConsumers(Assembly.GetExecutingAssembly());

});




builder.Services.AddHostedService<PingPublisher>();
var app = builder.Build();

app.Run();

