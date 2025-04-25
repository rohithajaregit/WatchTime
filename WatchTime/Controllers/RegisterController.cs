using Microsoft.AspNetCore.Mvc;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class RegisterController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public RegisterController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpPost]
    [Route("registeruser")]
    /// IActionResult
    public IActionResult registerUser(Users user)
    {
      if (ModelState.IsValid)
      {
        Users userdetails = new Users();
        userdetails.firstname = user.firstname;
        userdetails.lastname = user.lastname;
        userdetails.email = user.email;
        userdetails.mobilenumber = user.mobilenumber;
        userdetails.username = user.username;
        userdetails.password = user.password;
        userdetails.confirmpassword = user.confirmpassword;
   

        _unitOfWork.UserRepository.Add(userdetails);
        _unitOfWork.Save();
      }

      return Ok();
    }




  }
}
