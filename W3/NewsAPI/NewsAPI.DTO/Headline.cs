namespace NewsAPI.DTO
{
    public class Headline
    {
        public string? status { get; set; }
        public int totalResults { get; set; }
        public Article[]? articles { get; set; }
    }
}
