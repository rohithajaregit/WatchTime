using WatchTime.DataAccess.Repository;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Repository.IRepository
{
  public interface IQuantityRepository : IRepository<Quantity>
  {
    public void update(Quantity obj);

    public void save();
  }
}
