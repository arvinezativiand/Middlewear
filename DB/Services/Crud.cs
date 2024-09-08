using Middlewear.DB.EF;
using Middlewear.DB.Entity;

namespace Middlewear.DB.Services;

public class Crud
{
    private readonly EFcore _db;

    public Crud(EFcore db)
    {
        _db = db;
    }

    public void Add(User user)
    {
        _db.Users.Add(user);
        _db.SaveChanges();
    }
}
