using System.Collections;

namespace Lab08
{
    internal class Backpack : IEnumerable<Book>
    {
        private List<Book> books;
        private string dataFilePath;

        public Backpack()
        {
            books = new List<Book>();
            dataFilePath = @"C:\Users\kdkel\OneDrive\Documents\GitHub\Lab-08\Lab08\backpackdata.txt"; // Specify the file path to store backpack data
            LoadFromFile();
        }

        public void Pack(Book book)
        {
            books.Add(book);
            SaveToFile(); // Save the backpack data after adding a book
        }

        public Book Unpack(int index)
        {
            if (index >= 0 && index < books.Count)
            {
                Book book = books[index];
                books.RemoveAt(index);
                SaveToFile(); // Save the backpack data after removing a book
                return book;
            }
            return null;
        }

        public int Count()
        {
            return books.Count;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("The backpack is empty.");
            }

            return books.GetEnumerator();
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
                    foreach (var book in books)
                    {
                        writer.WriteLine($"{book.Title},{book.AuthorFirstName},{book.AuthorLastName},{book.NumberOfPages}");
                    }
                }
                Console.WriteLine("Backpack data saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving backpack data to file: {ex.Message}");
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
                                books.Add(new Book(bookData[0], bookData[1], bookData[2], numberOfPages));
                            }
                        }
                    }
                    Console.WriteLine("Backpack data loaded from file.");
                }
                else
                {
                    Console.WriteLine("Backpack data file not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading backpack data from file: {ex.Message}");
            }
        }
    }
}
