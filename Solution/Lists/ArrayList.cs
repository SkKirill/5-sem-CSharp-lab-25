using System.Collections;

namespace Solution.Lists;

internal class ArrayList<T> : IList<T> where T : IComparable<T>
{
    private const int MAX_LEVEL = 6;
    private const int CAPACITY = 1000;

    // Массив хранения значений
    private T[] values = new T[CAPACITY];

    /*
     next[level, index] = индекс следующего элемента
     -1 означает отсутствие ссылки

     Почему так?
     Мы эмулируем skip list, но вместо ссылок
     используем индексы массива.

     Это:
     ✔ быстрее по памяти
     ✔ проще сериализуется
     ✔ лучше кешируется процессором
    */
    private int[,] next = new int[MAX_LEVEL, CAPACITY];

    private int[] nodeLevel = new int[CAPACITY];
    private int count = 0;
    private int currentLevel = 1;

    private Random rand = new Random();

    public ArrayList()
    {
        for (int i = 0; i < MAX_LEVEL; i++)
        for (int j = 0; j < CAPACITY; j++)
            next[i, j] = -1;
    }

    private int RandomLevel()
    {
        int lvl = 1;
        while (rand.NextDouble() < 0.5 && lvl < MAX_LEVEL)
            lvl++;
        return lvl;
    }

    public int Add(T value)
    {
        if (count >= CAPACITY)
            throw new ListException("Capacity exceeded");

        int[] update = new int[MAX_LEVEL];
        int current = -1;

        // Поиск места вставки
        for (int i = currentLevel - 1; i >= 0; i--)
        {
            while (current != -1 &&
                   next[i, current] != -1 &&
                   values[next[i, current]].CompareTo(value) < 0)
            {
                current = next[i, current];
            }

            update[i] = current;
        }

        int lvl = RandomLevel();
        nodeLevel[count] = lvl;

        if (lvl > currentLevel)
            currentLevel = lvl;

        // вставка
        for (int i = 0; i < lvl; i++)
        {
            if (update[i] == -1)
            {
                next[i, count] = -1;
            }
            else
            {
                next[i, count] = next[i, update[i]];
                next[i, update[i]] = count;
            }
        }

        values[count] = value;
        count++;
        return count - 1;
    }

    public void Clear()
    {
        count = 0;
        currentLevel = 1;
    }

    public bool Contains(T value) => IndexOf(value) >= 0;

    public int IndexOf(T value)
    {
        for (int i = 0; i < count; i++)
            if (values[i].Equals(value))
                return i;
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
        if (index < 0 || index >= count)
            throw new ListException("Invalid index");

        for (int i = index; i < count - 1; i++)
            values[i] = values[i + 1];

        count--;
    }

    public IList<T> SubList(int from, int to)
    {
        ArrayList<T> sub = new();
        for (int i = from; i <= to; i++)
            sub.Add(values[i]);
        return sub;
    }

    public int Count => count;

    public T this[int index]
    {
        get => values[index];
        set => values[index] = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < count; i++)
            yield return values[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}