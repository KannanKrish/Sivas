namespace Sivas.Models;

public class Product : BaseEntity
{
    public ProductCategory Category { get; set; }
    public string Company { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public byte[] Image { get; set; }
    public bool Landscape { get; set; }
    public ProductEnergyStar EnergyStar { get; set; }
    public int Price { get; set; }
    public bool Offer { get; set; }
    public string Color { get; set; }
    public string Specification { get; set; }
    public string Description { get; set; }
}