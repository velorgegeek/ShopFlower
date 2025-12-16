

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
        public List<ProductInShoppingCard> ShoppingCard { get; set; }
        public User(int id, string fio, string phone, string mail, string hashPassword,role Role)
        {
            ID = id;
            Fio = fio;
            Phone = phone;
            Mail = mail;
            HashPassword = hashPassword;
            ShoppingCard = new List<ProductInShoppingCard>();
            this.Role = Role;
        }
        public override string ToString()
        {
            return Fio;
        }
        public void ShopCardDelete(List<ProductInShoppingCard> q)
        {
            var itemsToDelete = new List<ProductInShoppingCard>(q);
            foreach (ProductInShoppingCard Purchaseditem in itemsToDelete)
            {

                ShoppingCard.RemoveAll(item =>
            item.ProductVariation.id == Purchaseditem.ProductVariation.id);
            }
        }
        public void AddInCard(ProductVariation item)
        {
            ArgumentNullException.ThrowIfNull(item);

            var thisItem = ShoppingCard.FirstOrDefault(pr => pr.ProductVariation.id == item.id);
            if (thisItem != null)
            {
                thisItem.Quantity++;
            }
            else
            {
                ShoppingCard.Add(new ProductInShoppingCard(item, 1));
            }
        }
        public User() { }
    }
}
