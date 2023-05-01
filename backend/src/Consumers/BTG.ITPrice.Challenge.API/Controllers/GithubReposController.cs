using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BTG.ITPrice.Challenge.API.Controllers
{
    [ApiController]
    [Route("btg/github-repos")]
    public class GithubReposController : ControllerBase
    {
        [HttpGet("by-languages/{githubReposRequest}")]
        public async Task<string> Get(string request)
        {
            return "teste 11 ";
        }

        [HttpGet]
        public async Task<string> d()
        {
            return "teste";
        }
    }
}
