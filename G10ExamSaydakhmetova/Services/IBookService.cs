using G10ExamSaydakhmetova.Services.DTOs;

namespace G10ExamSaydakhmetova.Services
{
    public interface IBookService
    {
        Guid Addbook(BookDto book);

        void DeleteBook(Guid id);

        void UpdateBook(BookDto book);

        List<BookDto> GetAllBooks();

        BookDto GetBookById(Guid id);



        List<BookDto>GetAllBooksByAuthor(string author);

        BookDto GetTopRatedBook();

        List<BookDto> GetBooksPublishedAfterYear(int year);

        BookDto GetMostPopularBook();

        List<BookDto> SearchBooksByTitle(string keyword);

        List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);

        int GetTotalCopiesSoldByAuthor(string author);

        List<BookDto> GetBooksSortedByRating();

        List<BookDto> GetRecentBooks(int years);
    }
}