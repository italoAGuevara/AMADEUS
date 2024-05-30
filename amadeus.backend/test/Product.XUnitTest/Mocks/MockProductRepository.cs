
namespace Product.XUnitTest.Mocks
{
    public static class MockProductRepository
    {
        public static void AddDataProductRepository(ApplicationDbContext productDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var products = fixture.CreateMany<Domain.Product>().ToList();

            products.Add(fixture.Build<Domain.Product>()
               .With(tr => tr.Id, Guid.NewGuid)
               .Create()
           );

            productDbContextFake.Products!.AddRange(products);
            productDbContextFake.SaveChanges();

        }
    }
}
