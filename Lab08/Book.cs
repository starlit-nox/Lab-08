namespace Lab08
{
    public class Book
    {
        public string Title { get; private set; }
        public string AuthorFirstName { get; private set; }
        public string AuthorLastName { get; private set; }
        public int NumberOfPages { get; private set; }

        public Book(string title, string authorFirstName, string authorLastName, int numberOfPages)
        {
            Title = title;
            AuthorFirstName = authorFirstName;
            AuthorLastName = authorLastName;
            NumberOfPages = numberOfPages;
        }

        public override string ToString()
        {
            return $"\"{Title}\" by {AuthorFirstName} {AuthorLastName}, {NumberOfPages} pages";
        }
    }
}
