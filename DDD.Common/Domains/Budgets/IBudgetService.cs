using DDD.Common.Dimensions;
using DDD.Common.DocumentValues;

namespace DDD.Common.Domains.Budgets;

public interface IBudgetService
{
    Task AddAsync(DocumentKey key, DocumentValue value, DimensionTree dimensionTree, CancellationToken cancellationToken = default);
}
