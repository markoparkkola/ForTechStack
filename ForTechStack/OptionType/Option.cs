public static class Option
{
    public static Option<TValue> Create<TValue>(TValue value) => new Option<TValue>(value);
    public static OptionBase Some => OptionBase._some;
    public static OptionBase None => OptionBase._none;
}