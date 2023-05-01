using Microsoft.AspNetCore.Mvc;

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
