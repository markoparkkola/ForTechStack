namespace DDD.Common.Dimensions;

public record DimensionId(Guid Key)
{
    public readonly static DimensionId Empty = new(Guid.Empty);
}

