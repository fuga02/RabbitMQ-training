

using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest"
};

var connection = factory.CreateConnection();

var channel1 = connection.CreateModel();

channel1.QueueDeclare("order_queue",false,false,false,null);


var consumer = new EventingBasicConsumer(channel1);

consumer.Received += (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine(message + "received");

    channel1.BasicAck(args.DeliveryTag,false);
};

channel1.BasicConsume(consumer, "order_queue",false);

Console.ReadLine();