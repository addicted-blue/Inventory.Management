using Microsoft.EntityFrameworkCore;

namespace Inventory.Management.API.Modals.Context
{
    public class InventoryDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public InventoryDbContext(DbContextOptions option): base(option)
        {
            InsertProducts();
        }

        private void InsertProducts()
        {

            if (!Products.Any())
            {

                Products.Add(new Product()
                {
                    Category = Category.Grocery,
                    Description = "Abc",
                    Id = Guid.NewGuid(),
                    Name = "1Pro",
                    Price = 100.00,
                    Unit = 10,
                    UnitType = UnitType.Quantity
                });

                Products.Add(new Product()
                {
                    Category = Category.Grocery,
                    Description = "Abc",
                    Id = Guid.NewGuid(),
                    Name = "2Pro",
                    Price = 100.00,
                    Unit = 10,
                    UnitType = UnitType.Quantity
                });

                Products.Add(new Product()
                {
                    Category = Category.Grocery,
                    Description = "Abc",
                    Id = Guid.NewGuid(),
                    Name = "3Pro",
                    Price = 100.00,
                    Unit = 10,
                    UnitType = UnitType.Quantity
                });
                SaveChanges();
            }
        }
    }
}
