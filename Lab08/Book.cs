using System;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumberOfPages { get; set; }

    public Book(string title, string author, int numberOfPages)
    {
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
    }

    public override string ToString()
    {
        return $"{Title} by {Author}, {NumberOfPages} pages";
    }
}
