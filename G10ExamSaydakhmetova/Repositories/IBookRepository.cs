using G10ExamSaydakhmetova.DataAccess.Entities;

namespace G10ExamSaydakhmetova.Repositories
{
    public interface IBookRepository
    {
        Guid WriteBook(Book book);
        List<Book> ReadAllBooks();
        void RemoveBook(Guid bookId);
        Book GetBookById(Guid bookId);
        void UpdateBook(Book book);

    }
}