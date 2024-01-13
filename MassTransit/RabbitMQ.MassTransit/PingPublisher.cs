
using MassTransit;

namespace RabbitMQ.MassTransit
{
    public class PingPublisher : BackgroundService
    {
        private readonly ILogger<PingPublisher> _logger;
        private readonly IBus _busControl;

        public PingPublisher(ILogger<PingPublisher> logger, IBus busControl)
        {
            _logger = logger;
            _busControl = busControl;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Yield();

                var keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                {
                    _logger.LogInformation("pressed {Button}", keyPressed.Key.ToString());
                    await _busControl.Publish(new Ping(keyPressed.Key.ToString()));

                }
                else
                {
                    _logger.LogInformation("pressed {Button}, exiting", keyPressed.Key.ToString());
                    break;
                }

                await Task.Delay(1000, stoppingToken);
            }

        }
    }
}
