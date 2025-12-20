using DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IProductInShoppingCartRepository
    {
        bool Add(User user, ProductVariation pr);
        void Delete(ProductInShoppingCart product);
        void Update(ProductInShoppingCart product);
        List<ProductInShoppingCart> GetAll();

        List<ProductInShoppingCart> GetByUser(User user);
        void DeleteList(List<ProductInShoppingCart> list);
    }
}
