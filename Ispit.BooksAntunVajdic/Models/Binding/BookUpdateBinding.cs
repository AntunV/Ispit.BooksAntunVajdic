using Ispit.BooksAntunVajdic.Models.Dbo;

namespace Ispit.BooksAntunVajdic.Models.Binding
{
    public class BookUpdateBinding
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        
        public Author? Author { get; set; }
        
        public Publisher? Publisher { get; set; }
    }
}
