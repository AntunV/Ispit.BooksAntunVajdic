using Ispit.BooksAntunVajdic.Models.Dbo;

namespace Ispit.BooksAntunVajdic.Models.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        
        public Author? Author{ get; set; }
        public Publisher? Publisher{ get; set; }
   
        public int? AuthorId { get; set; }
        public int? PublisherId { get; set; }
        
        
       
    }
}
