namespace Solution.Lists;

public delegate bool CheckDelegate<in T>(T value);
public delegate int CompareDelegate<in T>(T a, T b);
public delegate void ActionDelegate<in T>(T value);
public delegate TO ConvertDelegate<in TI, out TO>(TI input);
public delegate IList<T> ListConstructorDelegate<T>();

public static class ListUtils
{
    public static bool Exists<T>(IList<T> list, CheckDelegate<T> check)
    {
        foreach (var item in list)
            if (check(item)) return true;
        return false;
    }

    public static T Find<T>(IList<T> list, CheckDelegate<T> check)
    {
        foreach (var item in list)
            if (check(item)) return item;

        throw new ListException("Element not found");
    }

    public static T FindLast<T>(IList<T> list, CheckDelegate<T> check)
    {
        T result = default;
        bool found = false;

        foreach (var item in list)
        {
            if (check(item))
            {
                result = item;
                found = true;
            }
        }

        if (!found)
            throw new ListException("Element not found");

        return result;
    }

    public static int FindIndex<T>(IList<T> list, CheckDelegate<T> check)
    {
        int index = 0;
        foreach (var item in list)
        {
            if (check(item)) return index;
            index++;
        }
        return -1;
    }

    public static int FindLastIndex<T>(IList<T> list, CheckDelegate<T> check)
    {
        int index = 0;
        int foundIndex = -1;

        foreach (var item in list)
        {
            if (check(item)) foundIndex = index;
            index++;
        }
        return foundIndex;
    }

    public static IList<T> FindAll<T>(
        IList<T> list,
        CheckDelegate<T> check,
        ListConstructorDelegate<T> constructor)
    {
        var result = constructor();

        foreach (var item in list)
            if (check(item))
                result.Add(item);

        return result;
    }

    public static IList<TO> ConvertAll<TI, TO>(
        IList<TI> list,
        ConvertDelegate<TI, TO> converter,
        ListConstructorDelegate<TO> constructor)
    {
        var result = constructor();

        foreach (var item in list)
            result.Add(converter(item));

        return result;
    }

    public static void ForEach<T>(IList<T> list, ActionDelegate<T> action)
    {
        foreach (var item in list)
            action(item);
    }

    public static void Sort<T>(IList<T> list, CompareDelegate<T> compare)
    {
        for (int i = 0; i < list.Count - 1; i++)
        for (int j = i + 1; j < list.Count; j++)
            if (compare(list[i], list[j]) > 0)
            {
                (list[i], list[j]) = (list[j], list[i]);
            }
    }

    public static bool CheckForAll<T>(IList<T> list, CheckDelegate<T> check)
    {
        foreach (var item in list)
            if (!check(item)) return false;

        return true;
    }

    public static ListConstructorDelegate<T> ArrayListConstructor<T>()
        where T : IComparable<T>
    {
        return () => new ArrayList<T>();
    }

    public static ListConstructorDelegate<T> LinkedListConstructor<T>()
        where T : IComparable<T>
    {
        return () => new LinkedList<T>();
    }
}