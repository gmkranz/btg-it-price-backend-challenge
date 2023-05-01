using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BTG.ITPrice.Challenge.API.Controllers
{
    [ApiController]
    [Route("btg/github-repos")]
    public class GithubReposController : ControllerBase
    {
        [HttpGet]
        public async Task<string> Get()
        {
            return "teste";
        }
    }
}
