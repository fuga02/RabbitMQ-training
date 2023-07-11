


using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    Port = 5672,
    UserName = "guest",
    Password = "guest",
    DispatchConsumersAsync = true
};

var connection = factory.CreateConnection();

var channel1 = connection.CreateModel();

channel1.QueueDeclare("message",false,false,false,null);
var consumer = new AsyncEventingBasicConsumer(channel1);

consumer.Received += async (sender, args) =>
{
    var message = Encoding.UTF8.GetString(args.Body.ToArray());
    Console.WriteLine(message + "saving...");

    await SendMessage();
};

channel1.BasicConsume(consumer,"message",false);

Console.ReadKey();

async Task SendMessage()
{
    await Task.Delay(1000);
    Console.WriteLine("saved");
}