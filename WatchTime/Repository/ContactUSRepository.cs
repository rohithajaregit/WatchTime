using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTime.DatabaseContext;
using WatchTime.Models;
using WatchTime.DataAccess.Repository;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Repository.IRepository;

namespace WatchTime.DataAccess.Repository
{
  public class ContactUSRepository : Repository<ContactUS>, IContactUsRepository
  {
    UserDbContext _db;
    public ContactUSRepository(UserDbContext db) : base(db)
    {
      _db = db;
    }
    public void Save()
    {
      _db.SaveChanges();
    }

    public void Update(ContactUS obj)
    {
      _db.ContactUs.Update(obj);
    }
  }
}






