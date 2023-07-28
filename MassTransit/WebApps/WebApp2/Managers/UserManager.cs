using Filed.Shared.Entities;
using WebApp2.Context;

namespace WebApp2.Managers;

public class UserManager
{
    private readonly AppDbContext _context;

    public List<User> Users = new List<User>();

    public UserManager(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> UserInformation(Guid id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == id);
        return user;
    }
}