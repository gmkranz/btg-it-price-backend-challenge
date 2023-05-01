namespace Application.Requests
{
    public class GithubRepoRequest
    {
        private readonly int DefaultPage = 1;
        private readonly int DefaultAntMaxPerPage = 30;
        public GithubRepoRequest() { }

        public GithubRepoRequest(string wordSearch, int? page, int? perPage, string language)
        {
            Page = page ?? DefaultPage;

            PerPage = perPage >= DefaultAntMaxPerPage ||
                 string.IsNullOrEmpty(perPage.ToString()) ? DefaultAntMaxPerPage : perPage;

            Languages = language;
            WordSearch = wordSearch;
        }

        public string Languages { get; set; }

        public int? Page { get; set; }

        public int? PerPage { get; set; }

        public string WordSearch { get; set; }
    }

}
