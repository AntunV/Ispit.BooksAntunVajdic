using AutoMapper;
using Ispit.BooksAntunVajdic.Models.Binding;
using Ispit.BooksAntunVajdic.Models.Dbo;
using Ispit.BooksAntunVajdic.Models.UserModels;
using Ispit.BooksAntunVajdic.Models.ViewModel;

namespace Ispit.BooksAntunVajdic.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<BookBinding, Book>();
            CreateMap<BookUpdateBinding, Book>();
            CreateMap<BookViewModel, BookUpdateBinding>();


        }
    }
}
