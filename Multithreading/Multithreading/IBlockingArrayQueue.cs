namespace Multithreading
{
    public interface IBlockingArrayQueue<T>
    {
        IBlockingArrayQueue<T> Enqueue(T e);
        (bool, IBlockingArrayQueue<T>) TryEnqueue(T e);
        
        T Dequeue();
        (bool, T) TryDequeue();

        IBlockingArrayQueue<T> Clear();
        (bool, IBlockingArrayQueue<T>) TryClear();

        int Size();
    }
}