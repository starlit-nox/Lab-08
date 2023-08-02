public class Book
{
    // title of the book
    public string Title { get; set; }

    // author of the book (concatenated first name and last name)
    public string Author { get; set; }

    // number of pages in the book
    public int NumberOfPages { get; set; }

    // constructor to create a new Book object
    public Book(string title, string authorFirstName, string authorLastName, int numberOfPages)
    {
        Title = title;
        Author = $"{authorFirstName} {authorLastName}";
        NumberOfPages = numberOfPages;
    }

    // override ToString method to get the formatted book information as a string
    public override string ToString()
    {
        return $"{Title} by {Author}, {NumberOfPages} pages";
    }
}
