
namespace DOMAIN
{
    public class Product
    {
        public int id { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public string category { get; set; }
        public List<ProductVariation> Variations { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
        public string Pricevar
        {
            get
            {
                return Variations.FirstOrDefault()?.Price.ToString();
            }
        }
        public string MainImagePath
        {
            get
            {
                return Variations?.FirstOrDefault()?.ImagePath;
            }
        }
        public Product(string name,string category,string Description)
        {
            this.Description = Description;
            this.Name = name;
            this.category = category;
        }
    }

}
