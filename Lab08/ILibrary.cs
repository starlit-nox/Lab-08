﻿public interface ILibrary : IReadOnlyCollection<Book>
{
    /// <summary>
    /// Add a Book to the library.
    /// </summary>
    void Add(string title, string firstName, string lastName, int numberOfPages);


    /// <summary>
    /// Remove a Book from the library with the given title.
    /// </summary>
    /// <returns>The Book, or null if not found.</returns>
    Book Borrow(string title);

    /// <summary>
    /// Return a Book to the library.
    /// </summary>
    void Return(Book book);

    /// <summary>
    /// Search for a book by title.
    /// </summary>
    /// <returns>The Book, or null if not found.</returns>
    Book Search(string title);
}
