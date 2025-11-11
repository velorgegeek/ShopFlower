using DOMAIN;


namespace Data.Interfaces
{
    public interface IProductsRepository
    {
        bool ProductAdd(Product product);

        bool ProductRemove(Product product);
        bool ProductUpdate(Product product);

        List<Product> GetProductsById(int id);
    }
}
