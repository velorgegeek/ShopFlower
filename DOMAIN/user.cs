

using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace DOMAIN
{
    public enum role
    {
        User,
        Admin,
    }
    public class User
    {
        public int ID { get; set; }
        public string Fio { get; set; }
        public string Phone { get; set; }
        public string? Mail { get; set; }
        public string HashPassword { get; set; }
        public role Role { get; set; } = role.User;
        public List<ProductInShoppingCart> ShoppingCard { get; set; }
        public User(int id, string fio, string phone, string mail, string hashPassword,role Role)
        {
            ID = id;
            Fio = fio;
            Phone = phone;
            Mail = mail;
            HashPassword = hashPassword;
            ShoppingCard = new List<ProductInShoppingCart>();
            this.Role = Role;
        }
        public override string ToString()
        {
            return Fio;
        }
        public void ShopCardDelete(List<ProductInShoppingCart> q)
        {
            var itemsToDelete = new List<ProductInShoppingCart>(q);
            foreach (ProductInShoppingCart Purchaseditem in itemsToDelete)
            {

                ShoppingCard.RemoveAll(item =>
            item.ProductVariation.id == Purchaseditem.ProductVariation.id);
            }
        }
        public bool AddInCard(ProductVariation item)
        {
            ArgumentNullException.ThrowIfNull(item);
            ShoppingCard.Add(new ProductInShoppingCart(item, 1));
            return true;
        }
        public void QuantityAdd(ProductInShoppingCart item)
        {
            ArgumentNullException.ThrowIfNull(item);
            item.Quantity++;
        }
        public User() {
            ShoppingCard = new List<ProductInShoppingCart>();
        }
    }
}
