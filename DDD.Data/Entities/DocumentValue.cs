using System.ComponentModel.DataAnnotations;

namespace DDD.Data.Entities;

public class DocumentValue
{
    [Key]
    public Guid Key { get; set; }
    public Guid ContainerKey { get; set; }
    public Guid AccountKey { get; set; }
    public Guid? DimensionKey { get; set; } // Postgresql would have array types!
    public DateTime Month { get; set; }
    public decimal Value { get; set; }
}
