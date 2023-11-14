namespace BlogApp.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}

