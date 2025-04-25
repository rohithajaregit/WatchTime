using Microsoft.AspNetCore.Mvc;
using WatchTime.DataAccess.Repository.IRepository;
using WatchTime.Models;

namespace WatchTime.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ContactUsController : Controller
  {
    private readonly IUnitOfWork _unitOfWork;

    public ContactUsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    [HttpPost]
    [Route("contactus")]
    public IActionResult contactus([FromForm]ContactUS obj, IFormFile? image)
    {
      if (ModelState.IsValid)
      {
        ContactUS contactusObj = new ContactUS();
        contactusObj.firstname = obj.firstname;
        contactusObj.lastname = obj.lastname;
        contactusObj.city = obj.city;
        contactusObj.subject = obj.subject;
        contactusObj.filePath = "";

        if (image != null && image.Length > 0)
        {
          var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
          if (!Directory.Exists(uploadDir))
          {
            Directory.CreateDirectory(uploadDir);
          }

          // Save the file
          var filePath = Path.Combine(uploadDir, image.FileName);
          using (var stream = new FileStream(filePath, FileMode.Create))
          {
            image.CopyTo(stream);
          }

          contactusObj.filePath = "/images/" + image.FileName;

          _unitOfWork.ContactUsRepository.Add(contactusObj);
          _unitOfWork.Save();
        }
      }

      return Ok();
    }

    [HttpGet]
    [Route("downloadImage/{imageName}")]
    public IActionResult DownloadImage(string imageName)
    {
      if (string.IsNullOrEmpty(imageName))
      {
        return BadRequest("Image name is required.");
      }

      // Secure the file name to prevent directory traversal attacks
      var safeFileName = Path.GetFileName(imageName);

      var imagePath = Path.Combine("D:\\Web development\\WatchTime\\WatchTime\\wwwroot", "images", safeFileName);

      if (!System.IO.File.Exists(imagePath))
      {
        return NotFound("Image not found.");
      }

      var imageBytes = System.IO.File.ReadAllBytes(imagePath);
      var contentType = GetContentType(imagePath);

      return File(imageBytes, contentType, safeFileName);
    }

    private string GetContentType(string path)
    {
      var types = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
    {
        { ".png", "image/png" },
        { ".jpg", "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".gif", "image/gif" },
        { ".bmp", "image/bmp" },
        { ".webp", "image/webp" }
    };

      var ext = Path.GetExtension(path);
      return types.TryGetValue(ext, out var contentType) ? contentType : "application/octet-stream";
    }
  }
}



