using BooksApi.MongoDb.Hubs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.MongoDb.Dependencies
{
    public class MyRabbitMQListener
    {
        public IConnection connection { get; set; }
        public ConnectionFactory factory { get; set; }
        public IModel channel { get; set; }

        public MyRabbitMQListener()
        {
                this.factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
            this.connection = this.factory.CreateConnection();
            this.channel =  this.connection.CreateModel();
        }

        public void Register()
        {
            channel.QueueDeclare(queue: "newBooks",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

            var myConsumer = new EventingBasicConsumer(channel);

            //event handler - callback when a message is received

            myConsumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.Span);
                Console.WriteLine($"Message Received {message}");

                Task.Factory.StartNew(() => BooksNotificationHub.NotifyBookRelease(message));
            };

            channel.BasicConsume(queue: "newBooks", autoAck: true, consumer: myConsumer);

        }

        public void UnRegister()
        {
            this.connection.Close();
        }
    }
}
