namespace Domain.Entitites
{
    //TODO: add other properties

    public class GithubItemResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Full_name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public double Score { get; set; }
    }

}
