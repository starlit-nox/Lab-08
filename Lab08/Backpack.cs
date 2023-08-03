namespace Lab08
{
    internal class Backpack : IEnumerable<Book>
    {
        private List<Book> books;

        public Backpack()
        {
            books = new List<Book>();
        }

        public void Pack(Book book)
        {
            books.Add(book);
        }

        public Book Unpack(int index)
        {
            if (index >= 0 && index < books.Count)
            {
                Book book = books[index];
                books.RemoveAt(index);
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
            return books.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
