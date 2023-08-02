using System.Collections;
using System.Collections.Generic;

public class Library : ILibrary
{
    private Dictionary<string, Book> Storage;

    public int Count => Storage.Count;

    public Library()
    {
        Storage = new Dictionary<string, Book>();
    }

    public void Add(string title, string firstName, string lastName, int numberOfPages)
    {
        Book newBook = new Book(title, $"{firstName} {lastName}", numberOfPages);
        Storage.Add(newBook.Title, newBook);
    }

    public Book? Borrow(string title)
    {
        // check if the book exists in the storage, and if it does, remove and return it
        if (Storage.TryGetValue(title, out Book book))
        {
            Storage.Remove(title);
            return book;
        }
        return null;
    }

    public void Return(Book book)
    {
        // add the returned book back to the storage
        Storage[book.Title] = book;
    }

    public Book? Search(string title)
    {
        // check if the book exists in the storage, and if it does, return it
        if (Storage.TryGetValue(title, out Book book))
        {
            return book;
        }
        return null;
    }

    // Implement IEnumerable<Book> explicitly
    IEnumerator<Book> IEnumerable<Book>.GetEnumerator()
    {
        return Storage.Values.GetEnumerator();
    }

    // Implement IEnumerable explicitly (non-generic)
    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Book>)this).GetEnumerator();
    }
}
