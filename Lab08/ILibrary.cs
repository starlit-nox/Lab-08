using Lab08;

public interface ILibrary : IEnumerable<Book>
{
    void Add(string title, string authorFirstName, string authorLastName, int numberOfPages);
    Book Borrow(string title);
    void Return(Book book);
    Book Search(string title); // Add the Search method to the interface
}
