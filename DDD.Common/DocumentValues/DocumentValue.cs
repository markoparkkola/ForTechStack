using DDD.Common.Date;
using DDD.Common.Dimensions;

namespace DDD.Common.DocumentValues;

public record DocumentValue(Accounts.AccountId Account, Month Month, IReadOnlyList<DimensionId> Dimensions, decimal Value)
{

}
