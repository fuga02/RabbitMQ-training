// See https://aka.ms/new-console-template for more information

using System.Text;
using RabbitMQ.Client;

Console.WriteLine("Producer");

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel1 = connection.CreateModel();


channel1.ExchangeDeclare("orders_topic",type:ExchangeType.Topic,durable:true);

channel1.BasicPublish("orders_topic","confirmed.paid",null,Encoding.UTF8.GetBytes("order1 confirmed and paid"));

channel1.BasicPublish("orders_topic","confirmed.notPaid",null,Encoding.UTF8.GetBytes("order2 confirmed but not paid"));

channel1.BasicPublish("orders_topic",string.Empty,null,Encoding.UTF8.GetBytes("order3 created and paid"));

channel1.BasicPublish("orders_topic", "created.notPaid", null,Encoding.UTF8.GetBytes("order4 created but not paid"));


Console.ReadKey();