

using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer");

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.ExchangeDeclare("orders", type:ExchangeType.Fanout, durable:true);

var body = Encoding.UTF8.GetBytes("order1");

channel.BasicPublish(exchange:"orders", routingKey:string.Empty, null,body);

Console.ReadKey();