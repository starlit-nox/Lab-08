namespace Lab08
{
    public interface IBag<T> : IEnumerable<T>
    {
        // adds the item to the bag 
        void Pack(T item);
        //removes the item from bag at index and returns the item that was removed
        T Unpack(int index);
    }
}