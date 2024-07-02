using AutoMapper;
using Ispit.BooksAntunVajdic.Data;
using Ispit.BooksAntunVajdic.Models.Binding;
using Ispit.BooksAntunVajdic.Models.Dbo;
using Ispit.BooksAntunVajdic.Models.UserModels;
using Ispit.BooksAntunVajdic.Models.ViewModel;
using Ispit.BooksAntunVajdic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ispit.BooksAntunVajdic.Services.Implementations
{
    public class BookService : IBookService
    {

       
        private ApplicationDbContext db;
        private IMapper mapper;
      

        public BookService(ApplicationDbContext db,
            IMapper mapper)
        {
            
            this.db = db;
            this.mapper = mapper;
           
        }



        public async Task<BookViewModel> AddBook(BookBinding model)
        {
            var dbo = mapper.Map<Book>(model);
            db.Books.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<BookViewModel>(dbo);
        }
        public async Task<BookViewModel> GetBook(int id)
        {
            var dbo = await db.Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .FirstOrDefaultAsync(y => y.Id == id);
            return mapper.Map<BookViewModel>(dbo);

        }


        public async Task<BookViewModel> UpdateBook(BookUpdateBinding model)
        {
            var dbo = await db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(b => b.Id == model.Id);

            mapper.Map(model, dbo);
            await db.SaveChangesAsync();

            return mapper.Map<BookViewModel>(dbo);
        }


        public async Task<List<BookViewModel>> GetAllBooks()
        {
            var books = await db.Books
                .Include(x => x.Author)
                .Include(x => x.Publisher)
                .ToListAsync();

            return books.Select(x => mapper.Map<BookViewModel>(x)).ToList();
        }


        public async Task<BookViewModel> DeleteBook(int id)
        {
            var dbo = await db.Books
                .Include(y => y.Author)
                .Include(y => y.Publisher)
                .FirstOrDefaultAsync(y => y.Id == id);

            db.Books.Remove(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<BookViewModel>(dbo);

        }



    }
}
