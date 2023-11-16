namespace BlogApp.Models
{
    public class Article
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
