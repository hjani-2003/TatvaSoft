using Practice_Books.Models;

namespace Practice_Books.Data.Repositories.IRepository
{
    public interface IBookRepository
    {
        List<Books> GetAllUsersInMemory();
        List<Books> GetAllUsersFromDatabase();
        Books GetBookById(int id);
        void AddBook(Books user);
        List<Books> GetBooksOrderedByTitle();
        List<IGrouping<string, Books>> GetBooksGroupedByGenre();
        //List<dynamic> GetUsersWithRoles();
        List<BooksDepartmentDto> GetBooksWithDepartments();

    }
}
