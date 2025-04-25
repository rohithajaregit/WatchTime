using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace WatchTime.Models
{
  public class ContactUS
  {
    [Key]

    public string firstname { get; set; } = string.Empty;
    public string lastname { get; set; } = string.Empty;
    public string city { get; set; } = string.Empty;
    public string subject { get; set; } = string.Empty;

    public string filePath { get; set; } = string.Empty ;
  }
}
