using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

var connection = factory.CreateConnection();

var channel1 = connection.CreateModel();

channel1.QueueDeclare("order_queue", false, false, false, null);

channel1.BasicPublish("", "order_queue", null, Encoding.UTF8.GetBytes("order1"));

Console.ReadKey();