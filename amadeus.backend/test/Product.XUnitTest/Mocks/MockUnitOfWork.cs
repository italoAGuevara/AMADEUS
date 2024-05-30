
namespace Product.XUnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();

            var mockConfiguration = new Mock<IConfiguration>();

            var options = new DbContextOptionsBuilder<Data.ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"ApplicationDbContext-{dbContextId}")
                .Options;

            var productDbContextFake = new Data.ApplicationDbContext(options);
            productDbContextFake.Database.EnsureDeleted();
            // Llenar la base de datos en memoria con datos falsos
            SeedData(productDbContextFake);
            var mockUnitOfWork = new Mock<UnitOfWork>(productDbContextFake);


            return mockUnitOfWork;
        }

        private static void SeedData(Data.ApplicationDbContext dbContext)
        {
            // Agregar datos falsos a las tablas
            dbContext.Products.AddRange(
                new Domain.Product { 
                    Id = Guid.Parse("cfd7d995-10fd-43d6-b86e-560c2f3c568c"), 
                    Name = "Product 1", 
                    Price = 10, 
                    BarCode = "barcode1" ,
                    Description = "description",
                    StockQuantity = 1,
                    TmStmp = DateTime.Now,
                },
                new Domain.Product
                {
                    Id = Guid.Parse("6080eb0c-f1aa-4dc6-9996-75cf70acbf1f"),
                    Name = "Product 2",
                    Price = 10,
                    BarCode = "barcode2",
                    Description = "description",
                    StockQuantity = 2,
                    TmStmp = DateTime.Now,
                },
                new Domain.Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Product 3",
                    Price = 10,
                    BarCode = "barcode3",
                    Description = "description",
                    StockQuantity = 3,
                    TmStmp = DateTime.Now,
                }
            );

            dbContext.SaveChanges();
        }
    }
}
