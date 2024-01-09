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
            #region no piroirity
            //consumer.Received += (model, ea) =>
            //{
            //    // Convert the message to a string
            //    string message = Encoding.UTF8.GetString(ea.Body.ToArray());
            //    Thread.Sleep(1000);
            //    Console.WriteLine($"from {queueName} Received message: {message}");
            //};

            //// Subscribe to the queue

            //channel.BasicConsume(queueName, true, consumer);
            #endregion
            channel.BasicQos(0, 1, false);
            consumer.Received += (model, ea) =>
            {
                // Convert the message to a string
                string message = Encoding.UTF8.GetString(ea.Body.ToArray());
                Thread.Sleep(1000);
                Console.WriteLine($"from {queueName} Received message: {message}");
                channel.BasicAck(ea.DeliveryTag, false);
            };

            // Subscribe to the queue

            channel.BasicConsume(queueName, false, consumer);

            #region piroirity queue


            #endregion
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();




            channel.Close();
            connection.Close();
        }
    }
}
