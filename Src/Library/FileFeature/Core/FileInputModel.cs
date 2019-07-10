using Microsoft.AspNetCore.Http;

namespace FileFeature.Core
{
  public class FileInputModel
  {
    public IFormFile FileToUpload { get; set; }
  }
}
