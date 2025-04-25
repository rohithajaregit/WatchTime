using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTime.DatabaseContext;
using WatchTime.Models;
using WatchTime.DataAccess.Repository;
using WatchTime.DataAccess.Repository.IRepository;

namespace WatchTime.DataAccess.Repository
{
    public class UserRepository : Repository<Users>, IUserRepository
    {
        UserDbContext _db;
        public UserRepository(UserDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Users obj)
        {
            _db.User.Update(obj);
        }
    }
}
