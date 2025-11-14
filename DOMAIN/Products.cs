
namespace DOMAIN
{
    public class Product
    {
        public int id { get; set; }
        public string name {  get; set; }
        public int category { get; set; }
        public List<ProductVariation> Variations { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
    }

}
