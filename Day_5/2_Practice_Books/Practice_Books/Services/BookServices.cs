using Microsoft.EntityFrameworkCore;
using Practice_Books.Models;
using Practice_Books.Data;

namespace Practice_Books.Services
{
    public class BookServices
    {
        // private readonly List<Books> _books;
        private readonly LibDbContext _books;
        public BookServices(LibDbContext book)
        {
            _books = book;
            //new LibDbContext.{
            //  new Books { Id = 1, Title = "1984", Author = "GeorgeOrwell", Genre = "Dystopian" },
            //  new Books { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Fiction" },
            //  new Books { Id = 3, Title = "Sapians", Author = "Yuval Noah Harrari", Genre = "History" },
            //  new Books { Id = 4, Title = "Valley of Peace", Author = "Po Xhang", Genre = "Fiction" },
            //  new Books { Id = 5, Title = "Dan Brown", Author = "I dont know", Genre = "Mystery" }
            //};
        }

        public List<Books> GetAll() => _books.Book.ToList();
        public Books GetById(int id) => _books.Book.FirstOrDefault(b => b.Id == id);
        public void Add(Books book)
        {
            _books.Book.Add(book);
            _books.SaveChanges();
        }
        public void Update(Books book)
        {
            var index = _books.Book.Find(book.Id);
            if (index != null)
            {
                index.Author = book.Author;
                index.Title = book.Title;
                index.Genre = book.Genre;
                index.DepartmentId = book.DepartmentId;
                _books.SaveChanges();
                // _books[index] = book;
            }
        }
        public void Delete(int id)
        {
            var book = _books.Book.Find(id);
            if (book != null)
            {
                _books.Remove(book);
                _books.SaveChanges();
            }
        }
    }
}
