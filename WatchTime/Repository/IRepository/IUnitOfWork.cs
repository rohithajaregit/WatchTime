using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTime.Repository.IRepository;

namespace WatchTime.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        IContactUsRepository ContactUsRepository { get; set; }

      IBrandRepository BrandRepository { get; set; }

      IQuantityRepository QuantityRepository { get; set; }
    public void Save();
    }
}
