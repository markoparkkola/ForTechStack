
namespace DDD.Common.Dimensions;

public record DimensionTree
{
    public Dimension GetByKey(Guid? key)
        => Dimension.Empty;
}
