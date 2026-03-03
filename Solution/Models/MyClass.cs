namespace Solution.Models;

public class MyClass : IComparable<MyClass>
{
    public int Number { get; set; }

    public MyClass(int number)
    {
        Number = number;
    }

    public int CompareTo(MyClass other)
    {
        return Number.CompareTo(other.Number);
    }

    public override string ToString()
    {
        return $"MyClass({Number})";
    }
}