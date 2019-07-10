using System.IO;
using System.Threading.Tasks;

using FileFeature.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEndWeb.Controllers
{
  public abstract class FileServiceBaseController : Controller
  {
    public IConfiguration Configuration { get; }

    public FileServiceBaseController(IConfiguration configuration) => this.Configuration = configuration;

    private string GetStaticFilesRootDirectory() => this.Configuration.GetSection("StaticFilesRootDirectory")["StaticFilesDirectory"];

    protected async Task<IActionResult> Download(string filename)
    {
      if(filename == null)
      {
        return this.Content("filename not present");
      }

      var path = Path.Combine(Directory.GetCurrentDirectory(), this.GetStaticFilesRootDirectory(), filename);

      var memory = new MemoryStream();

      using(var stream = new FileStream(path, FileMode.Open))
      {
        await stream.CopyToAsync(memory);
      }

      memory.Position = 0;

      return this.File(memory, FileMain.GetContentType(path), Path.GetFileName(path));
    }
  }
}