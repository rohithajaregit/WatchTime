using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Org.BouncyCastle.Asn1.X509;

namespace WatchTime.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ProductImage : Controller
  {
    public string _folder = "D:\\Web development\\Images_Time";


    [HttpGet("filename")]
    public async Task<IActionResult> Product(string fileName)
    {


      fileName = _folder + "\\" + fileName.Replace("~", "\\");
      try
      {
        if (System.IO.File.Exists(fileName))
        {

          var provider = new FileExtensionContentTypeProvider();
          if (!provider.TryGetContentType(fileName, out var contentType))
          {
            contentType = "application/octet-stream";
          }

          var imageData = await System.IO.File.ReadAllBytesAsync(fileName);

          var stream = new MemoryStream(imageData);

          return Ok(stream); // Adjust content type if needed
        }
        else
        {
          return NotFound();
        }
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
  }
}
