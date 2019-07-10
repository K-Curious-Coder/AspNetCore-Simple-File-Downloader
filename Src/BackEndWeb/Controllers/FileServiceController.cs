using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BackEndWeb.Controllers
{
  public class FileServiceController : FileServiceBaseController
  {
    public FileServiceController(IConfiguration configuration) : base(configuration) { }

    private string currentFilePath { get; } = "assets/PDF/";

    //[HttpGet("product-a-brochure")]
    //public Task<IActionResult> UClampBrochure() => this.Download(this.currentFilePath + "ProductA.pdf");

    //UClampBrochure
    [HttpGet("product-a-brochure")]
    public Task<IActionResult> DownloadBrochure() => this.Download(this.currentFilePath + "ProductA.pdf");

    [HttpGet("product-c-brochure")]
    public Task<IActionResult> UCosyBrochure() => this.Download(this.currentFilePath + "ProductC.pdf");

    [HttpGet("product-d-brochure")]
    public Task<IActionResult> UCosyAdvertFromFlyingStart() => this.Download(this.currentFilePath + "ProductD.pdf");
  }
}