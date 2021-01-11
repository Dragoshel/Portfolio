namespace Models
{
    public class Paragraph
    {
        public int Id { get; set; }
        public string Text { get; set; }
        // Foreign key to Article
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}