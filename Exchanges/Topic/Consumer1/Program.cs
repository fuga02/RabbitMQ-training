



using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Consumer 1");

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel1 = connection.CreateModel();

channel1.ExchangeDeclare("orders_topic", type:ExchangeType.Topic, durable:true);

var queueName = channel1.QueueDeclare().QueueName;

channel1.QueueBind(queueName,exchange: "orders_topic",routingKey:"confirmed.*",null);


var consumer = new EventingBasicConsumer(channel1);

consumer.Received += (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine(message + " received");
};

channel1.BasicConsume(consumer,queueName,autoAck:true);

Console.ReadLine();