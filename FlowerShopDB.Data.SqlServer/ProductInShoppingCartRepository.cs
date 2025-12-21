using Data.Interfaces;
using DOMAIN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShopDB.Data.SqlServer
{
    public class ProductInShoppingCartRepository : IProductInShoppingCartRepository
    {
        private readonly ShopDBContext _dbContext;
        public ProductInShoppingCartRepository(ShopDBContext context)
        {
            _dbContext = context;
        }
        public bool Add(User user,ProductVariation pr)
        {

            if (pr == null || user == null) return false;

            var tmp = _dbContext.productInShoppingCards.Where(i => i.ProductVariation.Id == pr.Id && i.UserId == user.ID).FirstOrDefault();
            if (tmp == null)
            {
                user.AddInCard(pr);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                user.QuantityAdd(tmp);
                _dbContext.Entry(tmp).CurrentValues.SetValues(tmp);
                _dbContext.SaveChanges();
                return true;
            }
        }

        public void Delete(ProductInShoppingCart pr)
        {
            ArgumentNullException.ThrowIfNull(pr);
            _dbContext.Remove(pr);
            _dbContext.SaveChanges();
        }
        public void DeleteList(List<ProductInShoppingCart> list)
        {
            ArgumentNullException.ThrowIfNull(list);
            foreach( var item in list)
            {
                _dbContext.Remove(item);
            }
            
        }
        public void Update(ProductInShoppingCart pr)
        {
            ArgumentNullException.ThrowIfNull(pr);
            _dbContext.Entry(pr).CurrentValues.SetValues(pr);
            _dbContext.SaveChanges();
        }
        public List<ProductInShoppingCart> GetAll()
        {
            return _dbContext.productInShoppingCards.ToList();
        }
        public List<ProductInShoppingCart> GetByUser(User user)
        {
            ArgumentNullException.ThrowIfNull(user);
            return _dbContext.productInShoppingCards
                .Include(pisc => pisc.ProductVariation)
                .Where(u => u.UserId == user.ID)
                .ToList();
        }
    }
}
