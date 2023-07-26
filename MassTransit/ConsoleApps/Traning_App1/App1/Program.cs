using App1;
bool check = true;
var users = new List<User>();
while (check)
{
    Console.WriteLine("Choose menu");
    Console.WriteLine("1 : Register");
    Console.WriteLine("2 : Login");
    Console.WriteLine("3 : Exit");
    Console.Write(">>>");
    var enter = Console.ReadLine();
    switch (enter)
    {
        case "1": AddUser(); break;
        case "2": AddUser(); break;
        case "3": Exit(); break;
    }
}

void AddUser()
{
    Console.Write("Enter ur name >>>");
    var name = Console.ReadLine();
    Console.Write("Enter ur email >>>");
    var email = Console.ReadLine();
    Console.Write("Enter ur password >>>");
    var password = Console.ReadLine();
    Console.Write("Enter ur username >>>");
    var username = Console.ReadLine();
    var user = new User()
    {
        Id = Guid.NewGuid(),
        Name = name,
        Email = email,
        Password = password,
        UserName = username
    };
    users.Add(user);

}

void Exit()
{
    check = false;
}