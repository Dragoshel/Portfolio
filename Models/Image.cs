namespace Portfolio.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Image_Data { get; set; }
        // Foreign key to Article
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}