namespace Application.Requests
{
    public class GithubRepoRequest
    {
        private int DefaultPage = 1;
        private int DefaultAntMaxPerPage = 30;
        public GithubRepoRequest() { }

        public GithubRepoRequest(int? page, int? perPage, string language) {
            Page = page ?? DefaultPage;

            PerPage = perPage >= DefaultAntMaxPerPage || 
                 string.IsNullOrEmpty(perPage.ToString()) ? DefaultAntMaxPerPage : perPage;

            Languages = language;
        }

        public string Languages { get; set; }

        public int? Page { get; set; }

        public int? PerPage { get; set; }
    }

}
