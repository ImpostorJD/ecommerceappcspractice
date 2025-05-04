namespace Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    private Product(){}

    public string Name { get; private set; } = default!;
    public List<string> Category {get; private set; } = new();
    public string Description { get; private set;} = default!;
    public string ImageFile { get; private set; } = default!;
    public decimal Price { get; private set; }

    public static Product Create(Guid id, string name, List<string> category,
        string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);

        var product = new Product 
        {
            Id = id,
            Name = name,
            Category = category,
            Description = description,
            ImageFile = imageFile,
            Price = price    
        };

        product.AddDomainEvent(new ProductCreatedEvent(product));

        return product;
    }

    public void Update(string name, List<string> category,
        string description, string imageFile, decimal price)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);  

        Name = name;
        Category = category;
        Description = description;
        ImageFile = imageFile;

        if (Price != price){
            Price = price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }

     public void Update(Product model)
    {
        ArgumentException.ThrowIfNullOrEmpty(model.Name);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(model.Price);  

        Name = model.Name;
        Category = model.Category;
        Description = model.Description;
        ImageFile = model.ImageFile;

        if (Price != model.Price){
            Price = model.Price;
            AddDomainEvent(new ProductPriceChangedEvent(this));
        }
    }
}