using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sivas.Models
{
    public class Products
    {
        public int Id { get; set; }
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
    public enum ProductCategory
    {
        Firdge, Wood, AC
    }
    public enum ProductEnergyStar
    {
        One, Two, Three, Four, Five
    }
}