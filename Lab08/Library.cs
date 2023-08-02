using Lab08;

public class Library : ILibrary
{
    private Dictionary<string, Book> Storage;

    public int Count { get; set; }

    public Library()
    {
        Storage = new Dictionary<string, Book>();
    }

    public void Add(string title, string firstName, string lastName, int numberOfPages)
    {
        Book newBook = new Book(title, $"{firstName} {lastName}");
        Storage.Add(newBook.Title, newBook);
    }
    Ienumrator Ienumrable.GetEnumrator()
    {
        {
            return this.GetEnumerator();
        }

        public IEnumerator<Book> GetEnumrator()

}
    public Book Borrow(string title)
    {
        Book returnedBook = Storage.GetValueOrDefault(title);
        return returnedBook;
    }

    public void Return(Book book)
    {
        Storage.Add(book.Title, book);
    }

    public Book Search(string title)
    {
        if (result = )
        {
            return Storage[title];
        }
        return null;
    }
}


