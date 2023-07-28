using MassTransit;

namespace WebApp1.Consumers;

public class ResultConsumer:IConsumer<string>
{
    public  Task Consume(ConsumeContext<string> context)
    {
        var result = context.Message;
        Console.WriteLine(result);
        return Task.CompletedTask;
    }
}