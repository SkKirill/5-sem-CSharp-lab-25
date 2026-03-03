namespace Solution.Lists;

public interface IList<T> : IEnumerable<T>
{
    int Add(T value);
    void Clear();
    bool Contains(T value);
    int IndexOf(T value);
    void Insert(int index, T value);
    void Remove(T value);
    void RemoveAt(int index);
    IList<T> SubList(int fromIndex, int toIndex);

    int Count { get; }
    T this[int index] { get; set; }
}