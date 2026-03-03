using System.Collections;

namespace Solution.Lists;

public class SkipList<T> : IList<T> where T : IComparable<T>
{
    private const int MaxLevel = 6;
    private readonly Random _rand = new();
    private readonly SkipNode<T> _head = new(MaxLevel, default);
    private int _level = 1;
    private int _count;

    private int RandomLevel()
    {
        int lvl = 1;
        while (_rand.NextDouble() < 0.5 && lvl < MaxLevel)
            lvl++;
        return lvl;
    }

    public int Add(T value)
    {
        SkipNode<T>[] update = new SkipNode<T>[MaxLevel];
        SkipNode<T> current = _head;

        for (int i = _level - 1; i >= 0; i--)
        {
            while (current.Forward[i] != null &&
                   current.Forward[i].Value.CompareTo(value) < 0)
                current = current.Forward[i];

            update[i] = current;
        }

        int newLevel = RandomLevel();

        if (newLevel > _level)
        {
            for (int i = _level; i < newLevel; i++)
                update[i] = _head;
            _level = newLevel;
        }

        SkipNode<T> newNode = new(newLevel, value);

        for (int i = 0; i < newLevel; i++)
        {
            newNode.Forward[i] = update[i].Forward[i];
            update[i].Forward[i] = newNode;
        }

        _count++;
        return _count - 1;
    }

    public void Clear()
    {
        for (int i = 0; i < MaxLevel; i++)
            _head.Forward[i] = null;
        _count = 0;
        _level = 1;
    }

    public bool Contains(T value) => IndexOf(value) >= 0;

    public int IndexOf(T value)
    {
        int index = 0;
        foreach (var item in this)
        {
            if (item.Equals(value))
                return index;
            index++;
        }

        return -1;
    }

    public void Insert(int index, T value)
    {
        Add(value);
    }

    public void Remove(T value)
    {
        RemoveAt(IndexOf(value));
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new ListException("Invalid index");

        List<T> temp = new(this);
        temp.RemoveAt(index);
        Clear();
        foreach (var item in temp)
            Add(item);
    }

    public IList<T> SubList(int from, int to)
    {
        if (from < 0 || to >= _count || from > to)
            throw new ListException("Invalid range");

        SkipList<T> sub = new();
        int i = 0;
        foreach (var item in this)
        {
            if (i >= from && i <= to)
                sub.Add(item);
            i++;
        }

        return sub;
    }

    public int Count => _count;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
                throw new ListException("Invalid index");

            int i = 0;
            foreach (var item in this)
            {
                if (i == index) return item;
                i++;
            }

            throw new ListException("Not found");
        }
        set => throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head.Forward[0];
        while (current != null)
        {
            yield return current.Value;
            current = current.Forward[0];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public List<List<T>> GetLevels()
    {
        List<List<T>> levels = new();

        for (int i = _level - 1; i >= 0; i--)
        {
            List<T> lvl = new();
            var current = _head.Forward[i];
            while (current != null)
            {
                lvl.Add(current.Value);
                current = current.Forward[i];
            }
            levels.Add(lvl);
        }

        return levels;
    }
}