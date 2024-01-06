using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConnection connection;
            IModel channel;
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = "localhost";
            factory.Port = 5672;
            connection = factory.CreateConnection();

            // Create a channel for communication
            channel = connection.CreateModel();



            Console.WriteLine("Enter the queue name to subscribe to:");
            string queueName = Console.ReadLine();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                // Convert the message to a string
                string message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Console.WriteLine($"from {queueName} Received message: {message}");
            };

            // Subscribe to the queue

            channel.BasicConsume(queueName, true, consumer);

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();




            channel.Close();
            connection.Close();
        }
    }
}
