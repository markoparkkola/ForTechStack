
namespace DDD.Common.Date;

public record Month(int Year, int MonthOfYear)
{
    public static Month FromDateTime(DateTime month) => new Month(month.Year, month.Month);
}
