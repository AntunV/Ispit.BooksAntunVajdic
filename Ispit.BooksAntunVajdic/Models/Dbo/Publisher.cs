namespace Ispit.BooksAntunVajdic.Models.Dbo
{
    public class Publisher
    {
        public int Id { get; set; }

        public string NamePublisher { get; set; }

        public ICollection<Book>? Books { get; set; }

    }
}
