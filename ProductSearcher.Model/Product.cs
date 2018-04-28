using System;

namespace ProductSearch.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? LastSold { get; set; }
        public long ShelfLife { get; set; }
        public string Department { get; set; }
        public double Price { get; set; }
        public string Unit { get; set; }
        public int XFor { get; set; }
        public double Cost { get; set; }
    }
}
