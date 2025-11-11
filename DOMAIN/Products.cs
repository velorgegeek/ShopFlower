
namespace DOMAIN
{
    public class Product
    {
        public string name {  get; set; }
        public int id { get; set; }
        public int category { get; set; }
        public string description { get; set; }
        public int stock { get; set; }
        public int? cost { get; set; }
        public KeyValuePair<int, int> size { get; set; }
        Product(string name, int category, string description, int stock, int? cost, KeyValuePair<int, int> size)
        {
            this.name = name;
            this.category = category;
            this.description = description;
            this.stock = stock;
            this.cost = cost;
            this.size = size;
        }
    }

}
