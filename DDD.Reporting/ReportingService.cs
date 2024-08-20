using DDD.Common;
using DDD.Common.Accounts;
using DDD.Common.Date;
using DDD.Common.Dimensions;
using DDD.Common.DocumentValues;
using DDD.Common.Domains.Reporting;

namespace DDD.Reporting;

public class ReportingService(IValueRepository valueRepository) : IReportingService
{
    public Task<IReadOnlyCollection<DocumentValue>> GetReportValuesAsync(
        DocumentKey key,
        AccountTree accountTree,
        DimensionTree dimensionTree,
        CancellationToken cancellationToken = default)
    {
        var values = valueRepository.GetAsync(
            key.Key,
            (x) => accountTree.GetByKey(x).Id,
            (x) => dimensionTree.GetByKey(x).Id,
            cancellationToken);

        // at this point we should calculate monthly values for account groups based on AccountTree
        // but I'm too lazy to write that out, because calculation should take different
        // dimension combinations into account as well and it is not clear how they should
        // even be added - there's at least three different ways to do it

        return values;
    }
}
