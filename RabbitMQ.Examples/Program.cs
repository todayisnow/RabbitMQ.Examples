using RabbitMQ.Client;
using System.Text;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   Create a connection to the RabbitMQ server
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






            #region create fanout exchange publish message to fanout exchange


            //// Declare a fanout exchange named "fanout-exchange"
            //channel.ExchangeDeclare("fanout-exchange", ExchangeType.Fanout, true, false, null);

            //// Declare a queue named "fanout-queue"
            //channel.QueueDeclare("fanout-queue1", true, false, false, null);
            //channel.QueueDeclare("fanout-queue2", true, false, false, null);

            //// Bind the queue to the fanout exchange with an empty routing key
            //channel.QueueBind("fanout-queue1", "fanout-exchange", "", null);
            //channel.QueueBind("fanout-queue2", "fanout-exchange", "", null);

            //// Prepare the message to be sent
            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");


            //// Publish the message to the fanout exchange
            //channel.BasicPublish("fanout-exchange", "", null, messageBodyBytes1);
            //channel.BasicPublish("fanout-exchange", "", null, messageBodyBytes2);

            //// Print a message indicating that the message has been sent
            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("fanout-queue1");
            //channel.QueueDelete("fanout-queue2");
            //channel.ExchangeDelete("fanout-exchange");

            //// Close the channel and connection

            #endregion

            #region Create Consumer for  exchange
            // Create a connection to the RabbitMQ server


            // Create a channel for communication


            // ReadMessageWithPushModel(channel);
            // ReadMessageWithPullModel(channel);

            // System.Console.WriteLine("Press [enter] to exit the sender app.");
            // System.Console.ReadLine();

            #endregion

            #region Direct Exchange

            //create direct exchange
            //channel.ExchangeDeclare("direct-exchange", ExchangeType.Direct, true, false, null);
            //channel.QueueDeclare("direct-queue1", true, false, false, null);
            //channel.QueueDeclare("direct-queue2", true, false, false, null);
            //channel.QueueDeclare("direct-queue3", true, false, false, null);
            //channel.QueueBind("direct-queue1", "direct-exchange", "info", null);
            //channel.QueueBind("direct-queue2", "direct-exchange", "error", null);
            //channel.QueueBind("direct-queue3", "direct-exchange", "warn", null);

            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");
            //byte[] messageBodyBytes3 = System.Text.Encoding.UTF8.GetBytes("Hello, world!3");

            //channel.BasicPublish("direct-exchange", "info", null, messageBodyBytes1);
            //channel.BasicPublish("direct-exchange", "error", null, messageBodyBytes2);
            //channel.BasicPublish("direct-exchange", "warn", null, messageBodyBytes3);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("direct-queue1");
            //channel.QueueDelete("direct-queue2");
            //channel.QueueDelete("direct-queue3");
            //channel.ExchangeDelete("direct-exchange");







            #endregion

            #region topic exchange
            //create topic exchange
            //channel.ExchangeDeclare("topic-exchange", ExchangeType.Topic, true, false, null);
            //channel.QueueDeclare("topic-queue1", true, false, false, null);
            //channel.QueueDeclare("topic-queue2", true, false, false, null);
            //channel.QueueDeclare("topic-queue3", true, false, false, null);
            //channel.QueueBind("topic-queue1", "topic-exchange", "*.image.*", null);
            //channel.QueueBind("topic-queue2", "topic-exchange", "#.image", null);
            //channel.QueueBind("topic-queue3", "topic-exchange", "image.#", null);

            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");
            //byte[] messageBodyBytes3 = System.Text.Encoding.UTF8.GetBytes("Hello, world!3");
            //byte[] messageBodyBytes4 = System.Text.Encoding.UTF8.GetBytes("Hello, world!4");

            //channel.BasicPublish("topic-exchange", "convert.image.jpg", null, messageBodyBytes1);
            //channel.BasicPublish("topic-exchange", "convert.bitmap.image", null, messageBodyBytes2);
            //channel.BasicPublish("topic-exchange", "image.bitmap.bit32", null, messageBodyBytes3);
            //channel.BasicPublish("topic-exchange", "image", null, messageBodyBytes4);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("topic-queue1");
            //channel.QueueDelete("topic-queue2");
            //channel.QueueDelete("topic-queue3");
            //channel.ExchangeDelete("topic-exchange");




            #endregion

            #region Header Exchange
            //create header exchange
            //channel.ExchangeDeclare("header-exchange", ExchangeType.Headers, true, false, null);
            //channel.QueueDeclare("header-queue1", true, false, false, null);
            //channel.QueueDeclare("header-queue2", true, false, false, null);
            //channel.QueueDeclare("header-queue3", true, false, false, null);
            //channel.QueueBind("header-queue1", "header-exchange", "", new Dictionary<string, object> { { "x-match", "all" }, { "format", "jpeg" }, { "type", "bitmap" } });
            //channel.QueueBind("header-queue2", "header-exchange", "", new Dictionary<string, object> { { "x-match", "any" }, { "format", "jpeg" }, { "type", "bitmap" } });
            //channel.QueueBind("header-queue3", "header-exchange", "", new Dictionary<string, object> { { "x-match", "any" }, { "format", "bmp" }, { "type", "bitmap" } });

            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");
            //byte[] messageBodyBytes3 = System.Text.Encoding.UTF8.GetBytes("Hello, world!3");

            //IBasicProperties props = channel.CreateBasicProperties();
            //props.Headers = new Dictionary<string, object> { { "format", "jpeg" }, { "type", "bitmap" } };
            //channel.BasicPublish("header-exchange", "", props, messageBodyBytes1);

            //props = channel.CreateBasicProperties();
            //props.Headers = new Dictionary<string, object> { { "format", "bmp" }, { "type", "bitmap" } };
            //channel.BasicPublish("header-exchange", "", props, messageBodyBytes2);

            //props = channel.CreateBasicProperties();
            //props.Headers = new Dictionary<string, object> { { "format", "jpeg" }, { "type", "bitmap" } };
            //channel.BasicPublish("header-exchange", "", props, messageBodyBytes3);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("header-queue1");
            //channel.QueueDelete("header-queue2");
            //channel.QueueDelete("header-queue3");
            //channel.ExchangeDelete("header-exchange");

            #endregion

            #region default exchange
            //channel.QueueDeclare("default-queue", true, false, false, null);
            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");

            //channel.BasicPublish("", "default-queue", null, messageBodyBytes1);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("default-queue");
            #endregion

            #region exchange to exchange binding
            //channel.ExchangeDeclare("exchange1", ExchangeType.Direct, true, false, null);
            //channel.ExchangeDeclare("exchange2", ExchangeType.Direct, true, false, null);
            //channel.QueueDeclare("queue1", true, false, false, null);
            //channel.QueueDeclare("queue2", true, false, false, null);
            //channel.QueueBind("queue1", "exchange1", "queue1", null);
            //channel.QueueBind("queue2", "exchange2", "queue2", null);
            //channel.ExchangeBind("exchange2", "exchange1", "queue2", null);

            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");
            //byte[] messageBodyBytes3 = System.Text.Encoding.UTF8.GetBytes("Hello, world!3");

            //channel.BasicPublish("exchange1", "queue1", null, messageBodyBytes1);
            //channel.BasicPublish("exchange2", "queue2", null, messageBodyBytes2);
            //channel.BasicPublish("exchange1", "queue2", null, messageBodyBytes3);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();
            //channel.QueueDelete("queue1");
            //channel.QueueDelete("queue2");
            //channel.ExchangeDelete("exchange1");
            //channel.ExchangeDelete("exchange2");

            #endregion

            #region alternate exchange
            // fanout exchange is good to use as alternate exchange
            //channel.ExchangeDeclare("alternate-exchange", ExchangeType.Fanout, true, false, null);
            //channel.ExchangeDeclare("my-exchange", ExchangeType.Direct, true, false,
            //    new Dictionary<string, object> { { "alternate-exchange", "alternate-exchange" } });
            //channel.QueueDeclare("my-queue", true, false, false, null);
            //channel.QueueDeclare("unrouted-messages-queue", true, false, false, null);



            //channel.QueueBind("my-queue", "my-exchange", "my-queue", null);
            //channel.QueueBind("unrouted-messages-queue", "alternate-exchange", "", null);



            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");
            //byte[] messageBodyBytes2 = System.Text.Encoding.UTF8.GetBytes("Hello, world!2");

            //channel.BasicPublish("my-exchange", "my-queue", null, messageBodyBytes1);
            //channel.BasicPublish("my-exchange", "not_my_queue", null, messageBodyBytes2);

            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();

            //channel.QueueDelete("my-queue");
            //channel.QueueDelete("unrouted-messages-queue");
            //channel.ExchangeDelete("my-exchange");
            //channel.ExchangeDelete("alternate-exchange");

            #endregion

            #region Dead Letter Exchange
            //an exchange to which messages will be republished if they are rejected or expire.

            //channel.ExchangeDeclare("dead-letter-exchange", ExchangeType.Fanout, true, false, null);
            //channel.ExchangeDeclare("my-exchange", ExchangeType.Direct, true, false, null);
            //channel.QueueDeclare("my-queue", true, false, false, new Dictionary<string, object> { { "x-dead-letter-exchange", "dead-letter-exchange" } });
            //channel.QueueDeclare("dead-letter-queue", true, false, false, null);

            //channel.QueueBind("my-queue", "my-exchange", "my-queue", null);
            //channel.QueueBind("dead-letter-queue", "dead-letter-exchange", "", null);

            //byte[] messageBodyBytes1 = System.Text.Encoding.UTF8.GetBytes("Hello, world!1");

            //var properties = channel.CreateBasicProperties();

            //// Set expiration to 5 seconds (5000 milliseconds)
            //properties.Expiration = "5000";


            //channel.BasicPublish("my-exchange", "my-queue", properties, messageBodyBytes1);




            //System.Console.WriteLine("Message Sent");
            //System.Console.WriteLine("Press [enter] to exit the sender app.");
            //System.Console.ReadLine();

            //channel.QueueDelete("my-queue");
            //channel.QueueDelete("dead-letter-queue");
            //channel.ExchangeDelete("my-exchange");
            //channel.ExchangeDelete("dead-letter-exchange");

            #endregion

            //==============================================================



            #region work queues

            //Console.WriteLine("enter worker name");
            //var workerName = Console.ReadLine();


            //var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{

            //    var message = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
            //    System.Console.WriteLine($"{workerName} - Message Received {message}");
            //};
            //var consumerTag = channel.BasicConsume("q1", true, consumer);//true for autoack , false for manual ack

            //Console.WriteLine("Press [enter] to exit the sender app.");
            //Console.ReadLine();

            #endregion

            #region work queues with fair dispatch

            //Console.WriteLine("enter worker name");
            //var workerName = Console.ReadLine();

            //channel.BasicQos(0, 1, false);//prefetch count 1 tells rabbitmq to send only one message at a time to worker

            //var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
            //consumer.Received += (model, ea) =>
            //{

            //    var message = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
            //    System.Console.Write($"{workerName} - Message Received {message} ");
            //    Thread.Sleep(int.Parse(message) * 1000);
            //    channel.BasicAck(ea.DeliveryTag, false);
            //    Console.WriteLine($" Done");

            //};
            //var consumerTag = channel.BasicConsume("q1", false, consumer);//true for autoack , false for manual ack

            //Console.WriteLine("Press [enter] to exit the sender app.");
            //Console.ReadLine();

            #endregion



            //











            channel.Close();
            connection.Close();

        }

        public static void ReadMessageWithPushModel(IModel channel)
        {
            var consumer = new RabbitMQ.Client.Events.EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {

                var message = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                System.Console.WriteLine("Message Received {0}", message);

                //manual acknowledgement 
                channel.BasicAck(ea.DeliveryTag, false);
                //requeue if false then message will be discarded if true then message will be requeued
                //channel.BasicNack(ea.DeliveryTag, false, true);
            };
            var consumerTag = channel.BasicConsume("q1", false, consumer);//true for autoack , false for manual ack

        }
        public static void ReadMessageWithPullModel(IModel channel)
        {
            Console.WriteLine("Reading messages from queue. Press 'e' to exit.");

            while (true)
            {
                Console.WriteLine("Trying to get a message from the queue...");

                BasicGetResult result = channel.BasicGet("q1", true);
                if (result != null)
                {
                    string message = Encoding.UTF8.GetString(result.Body.ToArray());
                    Console.WriteLine("Message:" + message);
                }

                if (Console.KeyAvailable)
                {
                    var keyInfo = Console.ReadKey();
                    if (keyInfo.KeyChar == 'e' || keyInfo.KeyChar == 'E')
                        return;
                }

                Thread.Sleep(2000);
            }
        }


    }
}

