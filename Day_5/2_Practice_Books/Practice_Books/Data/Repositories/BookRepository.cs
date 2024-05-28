using Practice_Books.Data.Repositories.IRepository;
using Practice_Books.Models;

namespace Practice_Books.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibDbContext _context;

        public BookRepository(LibDbContext context)
        {
            _context = context;
        }

        public List<Books> GetAllUsersInMemory()
        {
            var users = _context.Book.ToList(); // Load data into memory
            return users.Where(u => u.Genre.Contains("Fiction")).ToList(); // Filter in memory
        }

        public List<Books> GetAllUsersFromDatabase()
        {
            var usersQuery = _context.Book.Where(u => u.Genre.Contains("Fiction")); // Create query
            return usersQuery.ToList(); // Execute query on the database
        }

        public Books GetBookById(int id)
        {
            return _context.Book.SingleOrDefault(u => u.Id == id);
        }

        public void AddBook(Books book)
        {
            _context.Book.Add(book);
            _context.SaveChanges();
        }

        // New Methods
        public List<Books> GetBooksOrderedByTitle()
        {
            return _context.Book.OrderBy(u => u.Title).ToList();
        }

        public List<IGrouping<string, Books>> GetBooksGroupedByGenre()
        {
            return _context.Book.GroupBy(u => u.Genre).ToList();
        }

        public List<BooksDepartmentDto> GetBooksWithDepartments()
        {
            var BooksWithDepartments = from book in _context.Book
                                 join department in _context.Department
                                 on book.Id equals department.Id
                                 select new BooksDepartmentDto
                                 {
                                     Id = book.Id,
                                     Title = book.Title,
                                     Name = department.Name
                                 };
            return BooksWithDepartments.ToList();
        }

    }
}
