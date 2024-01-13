using MassTransit;
using MassTransit.InMemory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });

});
builder.Services.AddHostedService<PingPublisher>();
var app = builder.Build();

app.Run();

