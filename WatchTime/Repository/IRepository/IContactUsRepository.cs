using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Repository.IRepository
{
  public interface IContactUsRepository : IRepository<ContactUS>
  {
    public void Update(ContactUS obj);
    public void Save();
  }
}
