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
            #region no piroirity

            //while (true)
            //{
            //    Console.WriteLine("Enter a message to send to the queue:");
            //    string message = Console.ReadLine();

            //    if (message == "exit")
            //    {
            //        break;
            //    }
            //    // Convert the message to a byte array
            //    byte[] messageBody = Encoding.UTF8.GetBytes(message);


            //    // Publish the message to the queue
            //    channel.BasicPublish("f", "", null, messageBody);
            //}

            #endregion

            #region piroirity queue
            //create fanout xchange
            channel.ExchangeDeclare("priority", ExchangeType.Fanout, true, false, null);
            //create queue that support priority
            Dictionary<string, object> props = new Dictionary<string, object>();
            props.Add("x-max-priority", 10);
            channel.QueueDeclare("priority", true, false, false, props);
            //bind queue to xchange
            channel.QueueBind("priority", "priority", "", null);



            //publish message with priority
            Console.WriteLine("publisher is ready to send messages, press enter to start sending");
            Console.ReadLine();
            SendMessage(channel, 1);
            SendMessage(channel, 1);
            SendMessage(channel, 1);

            SendMessage(channel, 2);
            SendMessage(channel, 2);
            //press any key to exit
            Console.WriteLine("press any key to exit");

            Console.ReadLine();

            #endregion

            channel.Close();
            connection.Close();


        }
        static void SendMessage(IModel channel, byte prioity)
        {
            var message = $"message with priority {prioity}";
            byte[] messageBody = Encoding.UTF8.GetBytes(message);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.Priority = prioity;

            // Publish the message to the queue
            channel.BasicPublish("priority", "", properties, messageBody);
            Console.WriteLine($"message with priority {prioity} sent");
        }
    }
}
