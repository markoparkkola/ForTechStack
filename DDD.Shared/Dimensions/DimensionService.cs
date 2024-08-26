using DDD.Common.Dimensions;

namespace DDD.Shared.Dimensions;

public class DimensionService : IDimensionService
{
    public Task<DimensionTree> GetAsync(CancellationToken cancellationToken = default) => 
        Task.FromResult(new DimensionTree());
}
