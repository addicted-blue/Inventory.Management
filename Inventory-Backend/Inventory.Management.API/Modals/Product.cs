using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.Management.API.Modals
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        [NotMapped]
        public IFormFile ImageUrl { get; set; }

        public double Price { get; set; }

        public int Unit { get; set; }

        public UnitType UnitType { get; set; }
    }

    public enum Category
    {
        Dairy = 1,
        Grocery,
        Stationery
    }

    public enum UnitType
    {
        Weight = 1,
        Package,
        Quantity
    }
}
