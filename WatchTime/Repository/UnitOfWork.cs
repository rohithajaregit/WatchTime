
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.DatabaseContext;
using WatchTime.DataAccess.Repository;
using WatchTime.Repository.IRepository;
using WatchTime.Repository;

namespace Dashboard.DataAccess.Repository
{
    public class UnitOfWork : WatchTime.DataAccess.Repository.IRepository.IUnitOfWork
    {
        private UserDbContext _db;

        public IUserRepository UserRepository { get; set; }

        public IContactUsRepository ContactUsRepository { get; set; }
         public IBrandRepository BrandRepository { get; set; }

          public IQuantityRepository QuantityRepository { get; set; }

    public UnitOfWork(UserDbContext db)
        {
            _db = db;

            UserRepository = new UserRepository(db);
            ContactUsRepository = new ContactUSRepository(db);
            BrandRepository = new BrandRepository(db);
            QuantityRepository = new QuantityRepository(db);

       }

        void IUnitOfWork.Save()
        {
            _db.SaveChanges();
        }
    }
}
