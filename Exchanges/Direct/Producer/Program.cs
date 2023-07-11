
using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer");

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel = connection.CreateModel();

channel.ExchangeDeclare("orders_direct",type:ExchangeType.Direct, durable:true);

channel.BasicPublish(exchange:"orders_direct",routingKey:"confirmed",null,Encoding.UTF8.GetBytes("order1 confirmed"));

channel.BasicPublish(exchange:"orders_direct",routingKey:"created",null,Encoding.UTF8.GetBytes("order2 created"));


Console.ReadKey();