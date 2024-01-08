using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Collections.Concurrent;
using System.Text;

namespace Requester
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


            #region smiple request reply
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    // Get the message
            //    var body = ea.Body;
            //    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
            //    System.Console.WriteLine("Received: {0}", message);
            //};

            //// Start consuming
            //channel.BasicConsume(queue: "ResponseQueue", autoAck: true, consumer: consumer);

            //while (true)
            //{
            //    // Create a message
            //    Console.WriteLine("Enter a message to send to the Replyer service");
            //    var message = Console.ReadLine();
            //    var body = System.Text.Encoding.UTF8.GetBytes(message);
            //    if (message == "exit")
            //    {
            //        return;
            //    }

            //    // Send the message
            //    channel.BasicPublish(exchange: "", routingKey: "RequestQueue", basicProperties: null, body: body);
            //}


            #endregion

            #region request reply with correlation id

            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{
            //    // Get the message
            //    var body = ea.Body;
            //    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
            //    System.Console.WriteLine("Received: {0} with corelation {1}", message, ea.BasicProperties.CorrelationId);
            //};

            //// Start consuming
            //channel.BasicConsume(queue: "ResponseQueue", autoAck: true, consumer: consumer);

            //while (true)
            //{
            //    // Create a message
            //    Console.WriteLine("Enter a message to send to the Replyer service");
            //    var message = Console.ReadLine();
            //    var body = System.Text.Encoding.UTF8.GetBytes(message);
            //    if (message == "exit")
            //    {
            //        return;
            //    }
            //    var props = channel.CreateBasicProperties();
            //    props.CorrelationId = Guid.NewGuid().ToString();
            //    props.ReplyTo = "ResponseQueue";
            //    // Send the message
            //    Console.WriteLine("Sending message with correlation {0}", props.CorrelationId);
            //    channel.BasicPublish(exchange: "", routingKey: "RequestQueue", basicProperties: props, body: body);
            //}

            #endregion

            #region request reply with header 

            ConcurrentDictionary<string, Data> correlationDictionary = new ConcurrentDictionary<string, Data>();

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                // Get the message
                string requestID = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["requestId"]);
                var body = ea.Body;

                Data request;
                if (correlationDictionary.TryGetValue(requestID, out request))
                {
                    var message = System.Text.Encoding.UTF8.GetString(body.ToArray());
                    var response = JsonConvert.DeserializeObject<Data>(message);

                    Console.WriteLine(" result of: " + request.Name + " = " + response.Name + " with requestId " + requestID);

                }


            };

            // Start consuming
            channel.BasicConsume(queue: "ResponseQueue", autoAck: true, consumer: consumer);

            while (true)
            {
                // Create a message
                Console.WriteLine("Enter a message to send to the Replyer service");
                var message = Console.ReadLine();
                var body = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Data { Id = 1, Name = message }));
                if (message == "exit")
                {
                    return;
                }
                var requestID = Guid.NewGuid().ToString();
                var requestData = new Data { Id = 1, Name = message };
                correlationDictionary.TryAdd(requestID, requestData);

                var props = channel.CreateBasicProperties();
                props.Headers = new Dictionary<string, object>();
                props.Headers.Add("requestId", Encoding.UTF8.GetBytes(requestID));
                props.ReplyTo = "ResponseQueue";
                // Send the message
                Console.WriteLine("Sending message with request {0}", requestID);
                channel.BasicPublish(exchange: "", routingKey: "RequestQueue", basicProperties: props, body: body);
            }

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
