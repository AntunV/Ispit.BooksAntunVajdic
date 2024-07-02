using Ispit.BooksAntunVajdic.Models.Binding;
using Ispit.BooksAntunVajdic.Models.ViewModel;

namespace Ispit.BooksAntunVajdic.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookViewModel> AddBook(BookBinding model);
        Task<BookViewModel> DeleteBook(int id);
        Task<List<BookViewModel>> GetAllBooks();
        Task<BookViewModel> GetBook(int id);
        Task<BookViewModel> UpdateBook(BookUpdateBinding model);

    }
}