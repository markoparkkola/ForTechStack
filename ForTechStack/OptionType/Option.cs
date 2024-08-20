public static class Option
{
    /// <summary>
    /// Creates new value of type TValue.
    /// </summary>
    /// <param name="value">The value which must not be null.</param>
    /// <returns>New Option.</returns>
    public static Option<TValue> Create<TValue>(TValue value) => new Option<TValue>(value);

    // Use the following two to compare if Option has value or not. Do not use null!

    public static OptionBase Some => OptionBase._some;
    public static OptionBase None => OptionBase._none;
}
