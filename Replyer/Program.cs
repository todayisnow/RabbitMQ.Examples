using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Replyer
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


            #region smiple request reply

            // Create a channel for communication
            //channel = connection.CreateModel();

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    // Get the message
            //    var body = ea.Body;
            //    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
            //    System.Console.WriteLine("Received: {0}", message);

            //    Thread.Sleep(int.Parse(message) * 1000);
            //    string response = "Response to " + message;
            //    var responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
            //    channel.BasicPublish(exchange: "", routingKey: "ResponseQueue", basicProperties: null, body: responseBytes);
            //};

            //// Start consuming
            //channel.BasicConsume(queue: "RequestQueue", autoAck: true, consumer: consumer);

            //Console.WriteLine("Press [enter] to exit.");
            //Console.ReadLine();
            #endregion

            #region request reply with correlation id

            //// Create a channel for communication
            //channel = connection.CreateModel();

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    // Get the message
            //    var body = ea.Body;
            //    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
            //    System.Console.WriteLine("Received: {0}", message);
            //    var correlationId = ea.BasicProperties.CorrelationId;

            //    Thread.Sleep(int.Parse(message) * 1000);
            //    string response = "Response to " + message;
            //    var responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
            //    var replyProperties = channel.CreateBasicProperties();
            //    replyProperties.CorrelationId = correlationId;
            //    channel.BasicPublish(exchange: "", routingKey: ea.BasicProperties.ReplyTo, basicProperties: replyProperties, body: responseBytes);
            //};

            //// Start consuming
            //channel.BasicConsume(queue: "RequestQueue", autoAck: true, consumer: consumer);

            //Console.WriteLine("Press [enter] to exit.");
            //Console.ReadLine();

            #endregion


            #region request reply with Header


            // Create a channel for communication
            channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                // Get the message
                var body = ea.Body;
                var bodyA = System.Text.Encoding.UTF8.GetString(body.ToArray());
                var message = JsonConvert.DeserializeObject<Data>(bodyA);
                System.Console.WriteLine("Received: {0}", message.Name);
                var correlationId = ea.BasicProperties.CorrelationId;

                Thread.Sleep(int.Parse(message.Name) * 1000);
                string response = JsonConvert.SerializeObject(message);
                var responseBytes = System.Text.Encoding.UTF8.GetBytes(response);
                var basicProperties = channel.CreateBasicProperties();
                basicProperties.Headers = new Dictionary<string, object>();
                basicProperties.Headers.Add("requestId", ea.BasicProperties.Headers["requestId"]);
                ;
                channel.BasicPublish(exchange: "", routingKey: ea.BasicProperties.ReplyTo, basicProperties: basicProperties, body: responseBytes);
            };

            // Start consuming
            channel.BasicConsume(queue: "RequestQueue", autoAck: true, consumer: consumer);

            Console.WriteLine("Press [enter] to exit.");
            Console.ReadLine();

            #endregion



            channel.Close();
            connection.Close();
        }
    }
    public class Data

    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
