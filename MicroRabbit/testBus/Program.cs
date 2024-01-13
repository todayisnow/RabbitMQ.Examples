using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using MicroRabbit.Infra.Bus;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace testBus
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Setup Dependency Injection
            var serviceProvider = ConfigureServices();

            // Create an instance of RabbitMQBus
            var rabbitMQBus = new RabbitMQBus(
                serviceProvider.GetRequiredService<IMediator>(),
                serviceProvider.GetRequiredService<IServiceScopeFactory>()
            );

            // Subscribe to events
            rabbitMQBus.Subscribe<MyEvent, MyEventHandler>();



            // Send a command
            var command = new MyCommand();
            command.CommandSeq = 1;
            await rabbitMQBus.SendCommand(command);

            // Publish an event

            Console.ReadLine();

        }

        static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Add MediatR and other services
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddTransient<IRequestHandler<MyCommand, bool>, MyCommandHandler>();
            services.AddTransient<MyEventHandler>();
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetService<IMediator>(), scopeFactory);
            });
            // services.AddTransient<IEventHandler<MyEvent>, MyEventHandler1>();
            // Add other services...

            return services.BuildServiceProvider();
        }
    }
    // Define your command by inheriting from Command base class
    public class MyCommand : Command
    {
        public int CommandSeq { get; set; }
        // Add properties and methods as needed
    }
    public class MyCommandHandler : IRequestHandler<MyCommand, bool>
    {
        private readonly IEventBus rabbitMQBus;

        public MyCommandHandler(IEventBus rabbitMQBus)
        {
            this.rabbitMQBus = rabbitMQBus;
        }

        public Task<bool> Handle(MyCommand request, CancellationToken cancellationToken)
        {
            var @event = new MyEvent();
            @event.EventSeq = request.CommandSeq;
            rabbitMQBus.Publish(@event);
            return Task.FromResult(true);
        }
    }

    // Define your event by inheriting from Event base class
    public class MyEvent : Event
    {
        public DateTime MyTime { get; set; } = DateTime.Now;
        public int EventSeq { get; set; }
        // Add properties and methods as needed
    }


    // Define your event handler by implementing IEventHandler<T>
    public class MyEventHandler : IEventHandler<MyEvent>
    {
        // Implement the Handle method to process the event
        public async Task Handle(MyEvent @event)
        {
            Console.WriteLine($"Received MyEvent with Property: {@event.EventSeq} at {@event.MyTime}");

        }
    }


}

