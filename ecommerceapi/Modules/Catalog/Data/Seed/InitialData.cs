namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products => 
    new List<Product> {
        Product.Create(new Guid(), "Sample Product 1", ["category 1", "category 2"], "Long description", "image file", 500),
        Product.Create(new Guid(), "Sample Product 1", ["category 2", "category 2"], "Long description", "image file", 500),
        Product.Create(new Guid(), "Sample Product 1", ["category 3", "category 2"], "Long description", "image file", 500),

    };
}