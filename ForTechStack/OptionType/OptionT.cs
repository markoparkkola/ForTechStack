public sealed class Option<T> : OptionBase
{
    private readonly T _value;

    private Option()
        : base(false)
    {
        _value = default!;
    }

    /// <summary>
    /// Return new Option type with value. If you try to give null as value, you'll get InvalidOperationException.
    /// Because there is no null!
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="InvalidOperationException">Do not pass nulls!</exception>
    public Option(T value)
        : base(true)
    {
        if (value is null)
        {
            throw new InvalidOperationException("There is no null.");
        }

        _value = value;
    }

    /// <summary>
    /// Returns value that this Option type contains, or if there is no value InvalidOperationException is thrown.
    /// Always remember to check if this is Option.Some or Option.None!
    /// </summary>
    public T Value => HasValue ? _value : throw new InvalidOperationException("There is no value.");

    public static Option<T> None => new Option<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Option<T> o)
        {
            return false; // should probably throw but base class handles it already
        }

        return Value!.Equals(o.Value);
    }

    // to make compiler happy
    public override int GetHashCode() => HasValue ? _value!.GetHashCode() : base.GetHashCode();

    public static explicit operator T(Option<T> option) => option.Value;
}
