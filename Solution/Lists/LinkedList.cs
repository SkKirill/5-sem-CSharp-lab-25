using System.Collections;

namespace Solution.Lists;

public class LinkedList<T> : IList<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value;
        public Node[] Forward;

        public Node(int level, T value)
        {
            Forward = new Node[level];
            Value = value;
        }
    }

    private const int MAX_LEVEL = 6;
    private Node head = new Node(MAX_LEVEL, default);
    private int level = 1;
    private int count = 0;
    private Random rand = new Random();

    private int RandomLevel()
    {
        int lvl = 1;
        while (rand.NextDouble() < 0.5 && lvl < MAX_LEVEL)
            lvl++;
        return lvl;
    }

    public int Add(T value)
    {
        Node[] update = new Node[MAX_LEVEL];
        Node current = head;

        for (int i = level - 1; i >= 0; i--)
        {
            while (current.Forward[i] != null &&
                   current.Forward[i].Value.CompareTo(value) < 0)
                current = current.Forward[i];

            update[i] = current;
        }

        int newLevel = RandomLevel();

        if (newLevel > level)
        {
            for (int i = level; i < newLevel; i++)
                update[i] = head;
            level = newLevel;
        }

        Node newNode = new Node(newLevel, value);

        for (int i = 0; i < newLevel; i++)
        {
            newNode.Forward[i] = update[i].Forward[i];
            update[i].Forward[i] = newNode;
        }

        count++;
        return count - 1;
    }

    public void Clear()
    {
        head = new Node(MAX_LEVEL, default);
        count = 0;
        level = 1;
    }

    public bool Contains(T value) => IndexOf(value) >= 0;

    public int IndexOf(T value)
    {
        int i = 0;
        foreach (var v in this)
        {
            if (v.Equals(value)) return i;
            i++;
        }

        return -1;
    }

    public void Insert(int index, T value) => Add(value);
    public void Remove(T value) => RemoveAt(IndexOf(value));

    public void RemoveAt(int index)
    {
        /* упрощено */
    }

    public IList<T> SubList(int from, int to)
    {
        LinkedList<T> sub = new();
        int i = 0;
        foreach (var v in this)
        {
            if (i >= from && i <= to)
                sub.Add(v);
            i++;
        }

        return sub;
    }

    public int Count => count;

    public T this[int index]
    {
        get
        {
            int i = 0;
            foreach (var v in this)
            {
                if (i == index) return v;
                i++;
            }

            throw new ListException("Invalid index");
        }
        set => throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = head.Forward[0];
        while (current != null)
        {
            yield return current.Value;
            current = current.Forward[0];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}