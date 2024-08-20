using DDD.Common.Accounts;
using DDD.Common.Dimensions;
using DDD.Common.DocumentValues;

namespace DDD.Common.Domains.Reporting;

public interface IReportingService
{
    Task<IReadOnlyCollection<DocumentValue>> GetReportValuesAsync(
        DocumentKey key,
        AccountTree accountTree,
        DimensionTree dimensionTree,
        CancellationToken cancellationToken = default
    );
}
