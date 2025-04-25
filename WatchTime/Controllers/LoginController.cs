using Microsoft.AspNetCore.Mvc;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class LoginController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public LoginController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("login")]
    /// IActionResult
    public IActionResult login(login logindetails)
    {

      var userResult = _unitOfWork.UserRepository.GetFirstOrDefault(u => u.username == logindetails.username & u.password == logindetails.password);

      if (userResult == null)
          return NotFound();

    return Ok();
    }
    
  }
}
