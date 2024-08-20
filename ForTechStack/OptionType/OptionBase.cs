public abstract class OptionBase
{
    class Internal : OptionBase
    {
        public Internal(bool hasValue)
            : base(hasValue)
        {

        }
    }

    internal static readonly OptionBase _some = new Internal(true);
    internal static readonly OptionBase _none = new Internal(false);

    protected OptionBase(bool hasValue)
    {
        HasValue = hasValue;
    }

    /// <summary>
    /// Do we have value or are we Option.None?
    /// </summary>
    public bool HasValue { get; private init; }

    /// <summary>
    /// Comparator. This allows for all kind of comparations to be made like:
    /// a == b where a or be is None => false
    /// a == b where a or b is null => throw
    /// a == b where both have values => compare the actual values
    /// </summary>
    /// <exception cref="InvalidOperationException">There is no null.</exception>
    public static bool operator ==(OptionBase a, OptionBase b)
    {
        if (a is null || b is null)
        {
            throw new InvalidOperationException("There is no null.");
        }

        if (a is Internal || b is Internal)
        {
            // Match only if we have value on both of them.
            // This makes the 'foo == Option.Some' to work.
            return a.HasValue == b.HasValue;
        }

        // Here caller wants most probably match the values, not
        // do we have values. Otherwise caller would be matching against
        // Internal type object(s).
        return a.Equals(b);
    }

    public static bool operator !=(OptionBase a, OptionBase b) => !(a == b);

    // following three methods are to make compiler happy

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            throw new InvalidOperationException("There is no null.");
        }
        return obj is OptionBase o ? o == this : false;
    }

    public override int GetHashCode()
    {
        // I'm not really sure how this should be done
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name}; HasValue = {HasValue}";
    }
}
