using System.Collections;

namespace Solution.Lists;

public class UnmutableList<T> : IList<T>
{
    private readonly IList<T> inner;

    public UnmutableList(IList<T> list)
    {
        inner = list;
    }

    private void Throw() =>
        throw new ListException("List is unmutable");

    public int Add(T value) { Throw(); return -1; }
    public void Clear() => Throw();
    public bool Contains(T value) => inner.Contains(value);
    public int IndexOf(T value) => inner.IndexOf(value);
    public void Insert(int index, T value) => Throw();
    public void Remove(T value) => Throw();
    public void RemoveAt(int index) => Throw();
    public IList<T> SubList(int fromIndex, int toIndex) =>
        new UnmutableList<T>(inner.SubList(fromIndex, toIndex));

    public int Count => inner.Count;
    public T this[int index] { get => inner[index]; set => Throw(); }

    public IEnumerator<T> GetEnumerator() => inner.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}