public interface ILibrary : IEnumerable<Book>
{
    void Add(string title, string firstName, string lastName, int numberOfPages);
    Book? Borrow(string title);
    void Return(Book book);
    Book? Search(string title);
}
