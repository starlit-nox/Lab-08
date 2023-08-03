using System.Collections;

namespace Lab08
{
    public class Library : ILibrary
    {
        private List<Book> storage;
        private string dataFilePath;

        public Library()
        {
            storage = new List<Book>();
            dataFilePath = @"C:\Users\kdkel\OneDrive\Documents\GitHub\Lab-08\Lab08\librarydata.txt"; // Specify the file path to store library data
            LoadFromFile();
        }

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

            // Save the library data to the file after adding a book
            SaveToFile();
        }

        public Book Borrow(string title)
        {
            // find the book to be borrowed in the storage
            Book borrowedBook = storage.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (borrowedBook != null)
            {
                // remove the borrowed book from the library
                storage.Remove(borrowedBook);

                // Save the library data to the file after borrowing a book
                SaveToFile();
            }
            return borrowedBook;
        }

        public void Return(Book book)
        {
            // check if the returned book is not null and add it back to the library
            if (book != null)
            {
                storage.Add(book);

                // Save the library data to the file after returning a book
                SaveToFile();
            }
        }

        public Book Search(string title)
        {
            return storage.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void SaveToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(dataFilePath))
                {
                    foreach (var book in storage)
                    {
                        writer.WriteLine($"{book.Title},{book.AuthorFirstName},{book.AuthorLastName},{book.NumberOfPages}");
                    }
                }
                Console.WriteLine("Library data saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving library data to file: {ex.Message}");
            }
        }

        private void LoadFromFile()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    using (StreamReader reader = new StreamReader(dataFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] bookData = line.Split(',');
                            if (bookData.Length == 4 && int.TryParse(bookData[3], out int numberOfPages))
                            {
                                storage.Add(new Book(bookData[0], bookData[1], bookData[2], numberOfPages));
                            }
                        }
                    }
                    Console.WriteLine("Library data loaded from file.");
                }
                else
                {
                    Console.WriteLine("Library data file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading library data from file: {ex.Message}");
            }
        }
    }
}
