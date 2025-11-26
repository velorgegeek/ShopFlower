
namespace DOMAIN
{
    public class Product
    {
        public Guid id { get; set; } = Guid.NewGuid();
        public string Name {  get; set; }
        public string category { get; set; }
        public List<ProductVariation> Variations { get; set; }
        public List<ProductAttribute> Attributes { get; set; }
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
        //public Product(string name, CategoryProduct category,string Description)
        //{
        //    this.Description = Description;
        //    this.Name = name;
        //    this.category = category;
        //    Variations = new List<ProductVariation>();
        //    Attributes = new List<ProductAttribute>();
        //}
        public override string ToString()
        {
            return Name;
        }
        public Product(string name, string category, string Description)
        {
            this.Name = name;
            this.category = category;
            Variations = new List<ProductVariation>();
            Attributes = new List<ProductAttribute>();
        }


        public void AddVariation(string description, string ImagePath)
        {
            int VarId= Variations.Count;
            VarId++;
            var variation = new ProductVariation(this, description, ImagePath,VarId);

            Variations.Add(variation);
        }
    }

}
