


using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Consumer 2");

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.ExchangeDeclare("orders_direct",type:ExchangeType.Direct,durable:true);

var queueName = channel.QueueDeclare().QueueName;

channel.QueueBind(queueName, "orders_direct",routingKey:"confirmed",null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine(message + " received");
};

channel.BasicConsume(consumer, queueName, autoAck: true);

Console.ReadLine();


