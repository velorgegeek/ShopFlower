

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
        public User(int id, string fio, string phone, string mail, string hashPassword)
        {
            ID = id;
            Fio = fio;
            Phone = phone;
            Mail = mail;
            HashPassword = hashPassword;
            ShoppingCard = new List<ProductInShoppingCard>();
        }
        public override string ToString()
        {
            return Fio;
        }
        //public void ShopCardDelete(List<ProductInSale> q)
        //{
        //    foreach (ProductInSale item in q)
        //    {
        //        int i = ShoppingCard.IndexOf(item);
        //        if (i > -1)
        //        {
        //            ShoppingCard.RemoveAt(i);
        //        }
        //    }
        //}
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
    }
}
