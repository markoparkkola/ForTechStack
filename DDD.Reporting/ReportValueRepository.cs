using DDD.Common.Accounts;
using DDD.Common.Date;
using DDD.Common.Dimensions;
using DDD.Common.DocumentValues;
using DDD.Data;
using Microsoft.EntityFrameworkCore;

namespace DDD.Reporting;

public class ReportValueRepository(ApplicationDbContext context) : IValueRepository
{
    public async Task<IReadOnlyCollection<DocumentValue>> GetAsync(
        Guid documentKey,
        Func<Guid, AccountId> accountFn,
        Func<Guid, DimensionId> dimensionFn,
        CancellationToken cancellationToken)
    {
        var values = await context.DocumentValues.Where(x => x.ContainerKey == documentKey).ToListAsync(cancellationToken);
        var valuesByMonth = values.GroupBy(x => x.Month);

        List<DocumentValue> result = new();

        // This is just an example. I didn't have stamina to do nicely.
        // Basically we have values by month, where every value is connected to one account and 0..n dimensions.

        foreach (var monthlyValue in valuesByMonth)
        {
            var valuesByAccount = monthlyValue.GroupBy(x => x.AccountKey);
            foreach (var accountValue in valuesByAccount)
            {
                result.Add(
                    new DocumentValue(
                        accountFn(accountValue.Key),
                        Month.FromDateTime(monthlyValue.Key),
                        accountValue.Where(x => x.DimensionKey != null).GroupBy(x => x.DimensionKey).Select(x => dimensionFn(x.Key!.Value)).ToList(),
                        accountValue.Sum(x => x.Value)
                    )
                );
            }
        }

        return result;
    }
}
