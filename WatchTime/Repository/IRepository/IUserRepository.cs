using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTime.Models;

namespace WatchTime.DataAccess.Repository.IRepository
{
    public interface IUserRepository : IRepository<Users>
    {
        public void Update(Users obj);
        public void Save();
    }
}
