using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WatchTime.Models
{
  public class Users
  {
    [Key]
     public long userId { get; set; }

    public string firstname { get; set; } = string.Empty;
    public string lastname { get; set; } = string.Empty ;
    public string email { get; set; } = string.Empty;

    [Range(00000000, 9999999999)]
    public string mobilenumber { get; set; } = string.Empty;

    public string username { get; set; } = string.Empty;

    public string password { get; set; } = string.Empty;

    public string confirmpassword { get; set; } = string.Empty;

  }
}
