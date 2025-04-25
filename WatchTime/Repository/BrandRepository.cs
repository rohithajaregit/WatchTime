using WatchTime.DataAccess.Repository;
using WatchTime.DatabaseContext;
using WatchTime.Models;
using WatchTime.Repository.IRepository;

namespace WatchTime.Repository
{
  public class BrandRepository : Repository<Brand>, IBrandRepository
  {
    UserDbContext _db;
    public BrandRepository(UserDbContext db) : base(db)
    {
      _db = db;
    }
    public void Save()
    {
      _db.SaveChanges();
    }

    public void Update(Brand obj)
    {
      _db.Brand.Update(obj);
    }
  }
}
