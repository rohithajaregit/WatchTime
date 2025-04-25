using Dashboard.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SwimlaneController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public SwimlaneController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [Route("swimlane")]
    /// IActionResult
    //public ActionResult<IEnumerable<Brand[]>> GetUsers()
    // {
    //   var quantityData = _unitOfWork.QuantityRepository.GetAll().ToList();
    //   var data = _unitOfWork.BrandRepository.GetAll().ToList();
    //   return Ok();
    // }

    public List<StorageData> GetStorageData()
    {
      
      var brandList = _unitOfWork.BrandRepository.GetAll().ToList();
      var quantityList = _unitOfWork.QuantityRepository.GetAll().ToList();

      var customerData = from brand in brandList
                         join quantity in quantityList on brand.id equals quantity.id
                         select new StorageData()
                         {
                           brandname = brand.name,
                           totatStorage = quantity.quantity
                         };

     
      return customerData.ToList();

    }
  }
}
  

