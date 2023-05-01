using Application.Requests;
using Application.Services.Contracts;
using BTG.ITPrice.Challenge.Infrastucture.Refit.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTG.ITPrice.Challenge.API.Controllers
{
    [ApiController]
    [Route("btg/github-repos")]
    public class GithubReposController : ControllerBase
    {
        private readonly IGithubReposService _service;

        public GithubReposController(
            IGithubReposService service)
        {
            _service= service;
        }

        [HttpGet("by-languages")]
        public async Task<ActionResult<IEnumerable<GithubReposResponse>>> Get([FromQuery]GithubRepoRequest githubReposRequest)
        {
            var response = await _service.GetReposGithub(githubReposRequest);
            return Ok(new List<GithubReposResponse>());
        }
        [HttpGet("teste")]
        public  string Geet([FromQuery] GithubRepoRequest githubReposRequest)
        {
            var response =  _service.GetReposGitheub(githubReposRequest);
            return response;
        }

        [HttpGet]
        public async Task<string> d()
        {
            return "teste";
        }
    }
}
