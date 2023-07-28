using Filed.Shared.Entities;
using MassTransit;
using WebApp2.Context;

namespace WebApp2.Consumers;

public class UserConsumer:IConsumer<User>
{
    private readonly AppDbContext _context;
    public UserConsumer(AppDbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<User> context)
    {
        User? user = context.Message;

        Console.WriteLine(user.Name);
        _context.Users.Add(user);
        await context.Publish("User added");


    }
}