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


    private Book ConvertToEntity(BookCreateDto bookCreateDto)
    {
        return new Book
        {
            Id = Guid.NewGuid(),
            Title = bookCreateDto.Title,
            Author = bookCreateDto.Author,
            Pages = bookCreateDto.Pages,
            Rating = bookCreateDto.Rating,
            NumberOfCopiesSold = bookCreateDto.NumberOfCopiesSold,
            PublishedDate = bookCreateDto.PublishedDate
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
