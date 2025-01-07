using G10ExamSaydakhmetova.DataAccess.Entities;
using System.Text.Json;

namespace G10ExamSaydakhmetova.Repositories;

public class BookRepository : IBookRepository
{
    private readonly string _path;
    private List<Book> _books;

    public BookRepository()
    {
        _path = "../../../DataAccess/Data/Books.json";
        _books = new List<Book>();

        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _books = ReadAllBooks();
    }

    public Book GetBookById(Guid bookId)
    {

        foreach (var book in _books)
        {
            if (book.Id == bookId)
            {
                return book;
            }
        }

        throw new Exception($"Bunday id : {bookId} li kitob yo'q");
    }

    public List<Book> ReadAllBooks()
    {
        var booksJson = File.ReadAllText(_path);
        var books = JsonSerializer.Deserialize<List<Book>>(booksJson);

        return books;
    }

    public void RemoveBook(Guid bookId)
    {
        var book = GetBookById(bookId);
        _books.Remove(book);
        SaveData();
    }

    public void UpdateBook(Book book)
    {
        var updatingBook = GetBookById(book.Id);
        var index = _books.IndexOf(updatingBook);
        _books[index] = book;
        SaveData();
    }
    public Guid WriteBook(Book book)
    {
        _books.Add(book);
        SaveData();
        return book.Id;
    }

    private void SaveData()
    {
        var booksJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_path, booksJson);
    }


}















