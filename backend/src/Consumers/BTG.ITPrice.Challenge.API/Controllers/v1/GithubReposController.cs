using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BTG.ITPrice.Challenge.API.Controllers.v1
{
    [ApiController]
    [Route("v1.0/btg/github-repos")]
    public class GithubReposController : ControllerBase
    {
        private readonly IGithubReposService _service;

        public GithubReposController(
            IGithubReposService service)
        {
            _service = service;
        }

        [HttpGet("by-languages")]
        public async Task<ActionResult<GithubReposResponse>> Get([FromQuery] GithubRepoRequest githubReposRequest)
        {
            var response = await _service.GetReposGithub(githubReposRequest);
            return Ok(response);
        }
    }
}
