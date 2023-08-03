namespace Lab08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();
            Backpack myBackpack = new Backpack();

            while (true)
            {
                Console.WriteLine("Hello! Welcome to my Library");
                Console.WriteLine("Pick an option:");
                Console.WriteLine("1: View Books");
                Console.WriteLine("2: Add Book");
                Console.WriteLine("3: Borrow Book");
                Console.WriteLine("4: Return Book");
                Console.WriteLine("5: View Backpack");
                Console.WriteLine("6: Exit");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Library Books:");
                            foreach (var book in myLibrary)
                            {
                                Console.WriteLine(book);
                            }
                            break;

                        case 2:
                            AddBookToLibrary(myLibrary);
                            break;

                        case 3:
                            BorrowBookFromLibrary(myLibrary, myBackpack);
                            break;

                        case 4:
                            ReturnBookToLibrary(myLibrary, myBackpack);
                            break;

                        case 5:
                            Console.WriteLine("Books in your Backpack:");
                            if (myBackpack.Count() == 0)
                            {
                                Console.WriteLine("Your backpack is empty.");
                            }
                            else
                            {
                                int count = 1;
                                foreach (var book in myBackpack)
                                {
                                    Console.WriteLine($"{count}: {book.Title} by {book.AuthorFirstName} {book.AuthorLastName}, {book.NumberOfPages} pages");
                                    count++;
                                }
                            }
                            break;

                        case 6:
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid option. Please choose a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                }
            }
        }

        // Helper method to add a book to the library
        static void AddBookToLibrary(Library library)
        {
            Console.WriteLine("Enter the title of the book:");
            string title = Console.ReadLine();
            Console.WriteLine("Enter the author's first name:");
            string authorFirstName = Console.ReadLine();
            Console.WriteLine("Enter the author's last name:");
            string authorLastName = Console.ReadLine();
            Console.WriteLine("Enter the number of pages:");
            if (int.TryParse(Console.ReadLine(), out int numberOfPages))
            {
                library.Add(title, authorFirstName, authorLastName, numberOfPages);
                Console.WriteLine("Book added to the library.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number of pages.");
            }
        }

        // Helper method to borrow a book from the library
        static void BorrowBookFromLibrary(Library library, Backpack backpack)
        {
            Console.WriteLine("Enter the title of the book to borrow:");
            string borrowTitle = Console.ReadLine();
            Book borrowedBook = library.Borrow(borrowTitle);
            if (borrowedBook != null)
            {
                backpack.Pack(borrowedBook);
                Console.WriteLine($"You have borrowed {borrowedBook.Title}.");
            }
            else
            {
                Console.WriteLine("Book not found in the library.");
            }
        }

        // Helper method to return a book to the library
        static void ReturnBookToLibrary(Library library, Backpack backpack)
        {
            if (backpack.Count() == 0)
            {
                Console.WriteLine("There are no books to return.");
                return;
            }

            Console.WriteLine("Enter the number of the book to return:");
            if (int.TryParse(Console.ReadLine(), out int bookNumber) && bookNumber >= 1 && bookNumber <= backpack.Count())
            {
                Book returnedBook = backpack.Unpack(bookNumber - 1);
                if (returnedBook != null)
                {
                    library.Return(returnedBook);
                    Console.WriteLine($"You have returned {returnedBook.Title}.");
                }
                else
                {
                    Console.WriteLine("Book not found in your backpack.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid book number.");
            }
        }
    }
}
