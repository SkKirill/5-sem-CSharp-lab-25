namespace Solution.Lists;

internal class SkipNode<T>
{
    public T Value;
    public SkipNode<T>[] Forward;

    public SkipNode(int level, T value)
    {
        Forward = new SkipNode<T>[level];
        Value = value;
    }
}