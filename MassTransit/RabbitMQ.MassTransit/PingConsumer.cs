using MassTransit;

namespace RabbitMQ.MassTransit
{
    public class PingConsumer : IConsumer<Ping>
    {
        private readonly ILogger<PingConsumer> _logger;

        public PingConsumer(ILogger<PingConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Ping> context)
        {
            var button = context.Message.button;
            _logger.LogInformation("pressed {Button}", button.ToString());
            return Task.CompletedTask;
        }
    }
}
