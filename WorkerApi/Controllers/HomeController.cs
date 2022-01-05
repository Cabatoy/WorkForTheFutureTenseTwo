using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController :ControllerBase
    {

        public async Task<IActionResult> GetContentAsync()
        {
            var myTask = new HttpClient().GetAsync("https://www.google.com/");
            ///baska islemler
            var data = await myTask;
            return Ok(data);
        }
    }
}
