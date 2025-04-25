using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Repository.IRepository
{
  public interface IBrandRepository : IRepository<Brand>
  {
    public void Update(Brand obj);
    public void Save();
  }
}
