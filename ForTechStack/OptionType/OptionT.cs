public sealed class Option<T> : OptionBase
{
    private readonly T _value;

    private Option()
        : base(false)
    {
        _value = default!;
    }

    public Option(T value)
        : base(true)
    {
        if (value is null)
        {
            throw new InvalidOperationException("There is no null.");
        }

        _value = value;
    }

    public T Value => HasValue ? _value : throw new NullReferenceException("There is no value.");

    public static Option<T> None => new Option<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Option<T> o)
        {
            return false;
        }

        return Value!.Equals(o.Value);
    }

    // to make compiler happy
    public override int GetHashCode() => HasValue ? _value!.GetHashCode() : base.GetHashCode();
}
