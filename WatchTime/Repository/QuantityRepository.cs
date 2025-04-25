using WatchTime.DataAccess.Repository;
using WatchTime.DatabaseContext;
using WatchTime.Models;
using WatchTime.Repository.IRepository;

namespace WatchTime.Repository
{
  public class QuantityRepository : Repository<Quantity> , IQuantityRepository
  {
    UserDbContext _db;
    public QuantityRepository(UserDbContext db) : base(db)
    {
      _db = db;
    }
    

    public void save()
    {
      _db.SaveChanges();
    }

    public void update(Quantity obj)
    {
      _db.Quantity.Update(obj);
    }
  }
}
