namespace DDD.Common.Dimensions;

public record Dimension(DimensionId Id, string Name, DimensionId Parent)
{
    public static Dimension Empty => new Dimension(DimensionId.Empty, string.Empty, DimensionId.Empty);
}
