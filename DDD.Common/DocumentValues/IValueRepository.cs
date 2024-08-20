using DDD.Common.Accounts;
using DDD.Common.Dimensions;

namespace DDD.Common.DocumentValues;

public interface IValueRepository
{
    Task<IReadOnlyCollection<DocumentValue>> GetAsync(
        Guid documentKey, 
        Func<Guid, AccountId> accountFn,
        Func<Guid, DimensionId> dimensionFn,
        CancellationToken cancellationToken
    );
}
