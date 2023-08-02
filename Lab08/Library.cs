using System.Collections;

namespace Lab08
{
    internal class Library : IEnumerable<Book>
    {
        // private storage for holding the books in the library
        private List<Book> storage;

        // constructor to create a new Library object
        public Library()
        {
            storage = new List<Book>();
        }

        // method to add a new book to the library
        public void Add(string title, string authorFirstName, string authorLastName, int numberOfPages)
        {
            // check if any of the book information is invalid
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(authorFirstName) || string.IsNullOrEmpty(authorLastName) || numberOfPages <= 0)
            {
                Console.WriteLine("Invalid book information. Book not added.");
                return;
            }

            // create a new Book object and add it to the library
            Book newBook = new Book(title, authorFirstName, authorLastName, numberOfPages);
            storage.Add(newBook);
        }

        // method to borrow a book from the library based on its title
        public Book Borrow(string title)
        {
            // find the book to be borrowed in the storage
            Book borrowedBook = storage.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (borrowedBook != null)
            {
                // remove the borrowed book from the library
                storage.Remove(borrowedBook);
            }
            return borrowedBook;
        }

        // method to return a book to the library
        public void Return(Book book)
        {
            // check if the returned book is not null and add it back to the library
            if (book != null)
            {
                storage.Add(book);
            }
        }

        // get an enumerator to iterate over the books in the library
        public IEnumerator<Book> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        // non-generic version of the enumerator for the IEnumerable interface
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
