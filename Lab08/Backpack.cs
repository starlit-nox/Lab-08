namespace Lab08
{
    internal class Backpack : IBag<Book>
    {
        private List<Book> storage; // this is where the books will be stored

        public Backpack()
        {
            this.storage = new List<Book>(); // this initializes the storage list in the constructor
        }

        public void Pack(Book item)
        {
            this.storage.Add(item); // this adds a book to the storage
        }

        // this unpacks the book by index
        public Book Unpack(int index)
        {
            if (index >= 0 && index < this.storage.Count) // this checks if the index is valid
            {
                Book unpackedBook = this.storage[index]; // this gets the book at the specified index
                this.storage.RemoveAt(index); // this removes the book at the specified index
                return unpackedBook;
            }
            return null; // this returns null if the index is invalid
        }
        public Book Unpack(string title)
        {
            Book unpackedBook = this.storage.FirstOrDefault(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase)); // this finds the book by title using case-insensitive comparison
            if (unpackedBook != null)
            {
                this.storage.Remove(unpackedBook); // this removes the book from the storage if found
            }
            return unpackedBook;
        }

        // explicitly implemented to avoid naming conflict with the Library's Storage property
        IEnumerator<Book> IEnumerable<Book>.GetEnumerator()
        {
            return this.storage.GetEnumerator(); // this returns an enumerator for the books in the storage
        }

        // explicitly implemented to avoid naming conflict with the Library's Storage property
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.storage.GetEnumerator(); // this returns an enumerator for the books in the storage
        }
    }
}
