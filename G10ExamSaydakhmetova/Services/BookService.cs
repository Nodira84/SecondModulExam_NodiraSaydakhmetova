using G10ExamSaydakhmetova.DataAccess.Entities;
using G10ExamSaydakhmetova.Repositories;
using G10ExamSaydakhmetova.Services.DTOs;
using System.Runtime.CompilerServices;

namespace G10ExamSaydakhmetova.Services;

public class BookService : IBookService
{

    private readonly IBookRepository _bookRepository;


    public BookService()
    {
        _bookRepository = new BookRepository();
    }

    public Guid Addbook(BookDto bookDto);
    var book = ConvertToBookEntity(bookDto);





    private Book ConvertToBookEntity(BookDto bookDto)
    {
        return new Book()
        {
            Id = bookDto.Id ?? Guid.NewGuid(),
            Title = bookDto.Title,
            Author = bookDto.Author,
            Pages = bookDto.Pages,
            Rating = bookDto.Rating,
            NumberOfCopiesSold = bookDto.NumberOfCopiesSold,
            PublishedDate = bookDto.PublishedDate
        };
    }


    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        var books = _bookRepository.ReadAllBooks();
        var booksDto = new List<BookDto>();
        foreach (var book in books) 
        {
            if (book.Author == author)
            {
                booksDto.Add(ConvertToEntity(book);
            }
        }


    }

    private BookDto ConvertToEntity(Book book)
    {
        

    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
            var books = _bookRepository.ReadAllBooks();
            var booksDto = new List<BookDto>();

       


    }

    public List<BookDto> GetBooksSortedByRating()
    {
            var books = _bookRepository.ReadAllBooks();
            var booksDto = new List<BookDto>();



        }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
       



    }

    public BookDto GetMostPopularBook()
    {
        


    }

    public List<BookDto> GetRecentBooks(int years)
    {
        


    }

    public BookDto GetTopRatedBook()
    {
        


    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        


    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
        


    }
}
