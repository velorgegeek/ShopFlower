
namespace DOMAIN
{
    public class Product
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string Name {  get; set; }
        public CategoryProduct category { get; set; }
        public List<ProductVariation> Variations { get; set; }
        public string Description
        {
            get
            {
                return Variations.FirstOrDefault()?.Description;
            }
        }
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
        //public Product(string name, CategoryProduct category, string Description)
        //{
        //    this.Description = Description;
        //    this.Name = name;
        //    this.category = category;
        //    Variations = new List<ProductVariation>();
        //}
        public override string ToString()
        {
            return Name;
        }
        public Product(string name, CategoryProduct category)
        {
            this.Name = name;
            this.category = category;
            Variations = new List<ProductVariation>();
        }


        public void AddVariation(string description, string ImagePath, int price)
        {
            var variation = new ProductVariation(this, description, ImagePath,price);

            Variations.Add(variation);
        }
    }

}
