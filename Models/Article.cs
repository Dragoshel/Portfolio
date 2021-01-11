using System.Collections.Generic;

namespace Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Paragraph> Paragraphs { get; } = new List<Paragraph>();
        public List<Image> Images { get; } = new List<Image>();
    }
}