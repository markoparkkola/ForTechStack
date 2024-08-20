namespace DDD.Common.Dimensions;

public interface IDimensionService 
{
    Task<DimensionTree> GetAsync(CancellationToken cancellationToken = default);
}
