using RabbitMQ.Client;
using System.Text;

namespace Publisher
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

            while (true)
            {
                Console.WriteLine("Enter a message to send to the queue:");
                string message = Console.ReadLine();

                if (message == "exit")
                {
                    break;
                }
                // Convert the message to a byte array
                byte[] messageBody = Encoding.UTF8.GetBytes(message);


                // Publish the message to the queue
                channel.BasicPublish("f", "", null, messageBody);
            }






            channel.Close();
            connection.Close();
        }
    }
}
