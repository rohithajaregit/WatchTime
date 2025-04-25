using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;
using Newtonsoft.Json.Linq;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class updateSwimlaneData : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public updateSwimlaneData(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("updateSwimlaneData")]
    public IActionResult updateData([FromBody] StorageData storage)
    {
      var brandName = JToken.Parse(storage.brandname).ToString();
      if (Request.Headers.TryGetValue("brandname", out var headerValues))
      {
        brandName = headerValues;
      }
      var rowData = _unitOfWork.BrandRepository.GetFirstOrDefault(b => b.name == brandName);

      // If the row is not found, return a 404 response
      if (rowData == null)
      {
        return NotFound(new { message = "Brand not found" });
      }

      int brandId = rowData.id;

      var rowData1 = _unitOfWork.QuantityRepository.GetFirstOrDefault(b => b.id == brandId);

      //If the row is not found, return a 404 response
      if (rowData1 == null)
      {
        return NotFound(new { message = "Brand not found" });
      }

      rowData1.quantity = storage.totatStorage;

      // Save the changes to the database
      _unitOfWork.Save();

      // Return an appropriate response indicating success
      return Ok(new { message = "Brand updated successfully", data = rowData1 });
 

    }

  }

}
