using DOMAIN;


namespace Data.Interfaces
{
    public interface IProductsRepository
    {
        bool Add(Product product);

        bool Remove(Product product);
        bool Update(Product product);

        Product GetProductsById(Guid id);
        List<Product> GetAll();
    }
}
