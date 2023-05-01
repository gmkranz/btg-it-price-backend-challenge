using Application.Entities;
using System.Collections.Generic;

namespace BTG.ITPrice.Challenge.Infrastucture.Refit.Entities
{
    public class GithubReposResponse
    {
        public int Total_count { get; set; }
        public bool Incomplete_results { get; set; }
        public List<ItemsResponse>? items { get; set; }
    }
}
