using DataLoader.Dimentions;
using DataLoader.Facts;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLoader
{
    public class IsBiTestDwContext : DbContext
    {
        public IsBiTestDwContext() : base("isBiTestDw2")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PriceDiscountQuantity> PriceDiscountQuantityFacts { get; set; }

        public void CreateFacts(FileReader fileReader, DataParser dataParser)
        {
            var dataRow = new List<string>();
            long l = 0;

            while (true)
            {
                l++;
                dataRow = fileReader.GetNextDataRow();

                if (dataRow == null) break;

                var priceDiscountQuantity = new PriceDiscountQuantity();

                if (dataParser.CanParseIntoId(dataRow[0]))
                {
                    priceDiscountQuantity.CustomerId = dataParser.GetLastSuccessfullyParsedId();
                }

                if (dataParser.CanParseIntoId(dataRow[1]))
                {
                    priceDiscountQuantity.EmployeeId = dataParser.GetLastSuccessfullyParsedId();
                }

                if (dataParser.CanParseIntoId(dataRow[2]))
                {
                    priceDiscountQuantity.ProductId = dataParser.GetLastSuccessfullyParsedId();
                }

                if (dataParser.CanParseIntoInt(dataRow[3]))
                {
                    priceDiscountQuantity.Quantity = dataParser.GetLastSuccessfullyParsedInt();
                }

                if (dataParser.CanParseIntoFloat(dataRow[4]))
                {
                    priceDiscountQuantity.Price = dataParser.GetLastSuccessfullyParsedFloat();
                }

                if (dataParser.CanParseIntoFloat(dataRow[5]))
                {
                    priceDiscountQuantity.Discount = dataParser.GetLastSuccessfullyParsedFloat();
                }

                PriceDiscountQuantityFacts.Add(priceDiscountQuantity);
            }

            SaveChanges();
        }

        public void CreateDimentions(FileReader fileReader, DataParser dataParser)
        {
            var dataRow = new List<string>();
            var uniqueCustomersIds = new HashSet<int>();
            var uniqueEmployeesIds = new HashSet<int>();
            var uniqueProductsIds = new HashSet<int>();

            while (true)
            {
                dataRow = fileReader.GetNextDataRow();

                if (dataRow == null) break;

                if (dataParser.CanParseIntoId(dataRow[0]))
                {
                    uniqueCustomersIds.Add(dataParser.GetLastSuccessfullyParsedId());
                }

                if (dataParser.CanParseIntoId(dataRow[1]))
                {
                    uniqueEmployeesIds.Add(dataParser.GetLastSuccessfullyParsedId());
                }

                if (dataParser.CanParseIntoId(dataRow[2]))
                {
                    uniqueProductsIds.Add(dataParser.GetLastSuccessfullyParsedId());
                }
            }

            foreach (var customer in uniqueCustomersIds)
            {
                Customers.Add(
                    new Customer()
                    {
                        Id = customer
                    });
            }

            foreach (var employeeId in uniqueEmployeesIds)
            {
                Employees.Add(
                    new Employee()
                    {
                        Id = employeeId
                    });
            }

            foreach (var productId in uniqueProductsIds)
            {
                Products.Add(
                    new Product()
                    {
                        Id = productId
                    });
            }

            SaveChanges();
        }
    }
}
