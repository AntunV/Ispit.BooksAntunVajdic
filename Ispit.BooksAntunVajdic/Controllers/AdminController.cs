using AutoMapper;
using Ispit.BooksAntunVajdic.Models.Binding;
using Ispit.BooksAntunVajdic.Models.Dto;
using Ispit.BooksAntunVajdic.Services.Implementations;
using Ispit.BooksAntunVajdic.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Ispit.BooksAntunVajdic.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class AdminController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;


        public AdminController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }
       
        public async Task<IActionResult> Index()
        {
            var books = await bookService.GetAllBooks();
            return View(books);
        }


        public IActionResult AddBook()
        {
            return View();
        }


        [HttpPost]

        public async Task<IActionResult> AddBook(BookBinding model)
        {
                await bookService.AddBook(model);
                return RedirectToAction(nameof(Index));
            
        }


        public async Task<IActionResult> Edit(int id)
        {
            var model = await bookService.GetBook(id);
            var response = mapper.Map<BookUpdateBinding>(model); 
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookUpdateBinding model)
        {
            await bookService.UpdateBook(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

