namespace Lab08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library myLibrary = new Library();
            Backpack myBackpack = new Backpack();

            // load initial books into the library
            myLibrary.Add("No. 6: Volume 1", "Atsuko", "Asano", 176);
            myLibrary.Add("Solanin", "Inio", "Asano", 432);
            myLibrary.Add("I Married My Best Friend to Shut My Parents Up", "Kodama", "Naoko", 176);

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
                            // view books in the library
                            Console.WriteLine("Library Books:");
                            foreach (var book in myLibrary)
                            {
                                Console.WriteLine(book);
                            }
                            break;

                        case 2:
                            // add a book to the library
                            AddBookToLibrary(myLibrary);
                            break;

                        case 3:
                            // borrow a book from the library
                            BorrowBookFromLibrary(myLibrary, myBackpack);
                            break;

                        case 4:
                            // return a book to the library
                            ReturnBookToLibrary(myLibrary, myBackpack);
                            break;

                        case 5:
                            // view books in the backpack
                            Console.WriteLine("Books in your Backpack:");
                            int count = 1;
                            foreach (var book in myBackpack)
                            {
                                Console.WriteLine($"{count}: {book.Title} by {book.Author}, {book.NumberOfPages} pages");
                                count++;
                            }
                            break;

                        case 6:
                            // exit the program
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            // invalid option selected
                            Console.WriteLine("Invalid option. Please choose a valid option.");
                            break;
                    }
                }
                else
                {
                    // invalid input entered
                    Console.WriteLine("Invalid input. Please enter a valid option number.");
                }
            }
        }

        // helper method to add a book to the library
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
                // invalid number of pages entered
                Console.WriteLine("Invalid input. Please enter a valid number of pages.");
            }
        }

        // helper method to borrow a book from the library
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
                // book not found in the library
                Console.WriteLine("Book not found in the library.");
            }
        }

        // helper method to return a book to the library
        static void ReturnBookToLibrary(Library library, Backpack backpack)
        {
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
                    // book not found in the backpack
                    Console.WriteLine("Book not found in your backpack.");
                }
            }
            else
            {
                // invalid book number entered
                Console.WriteLine("Invalid input. Please enter a valid book number.");
            }
        }
    }
}
