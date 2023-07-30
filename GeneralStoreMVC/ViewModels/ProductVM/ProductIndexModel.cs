namespace ViewModels.ProductVM
{
    public class ProductIndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int QuantityInStock { get; set; }
        public double Price { get; set; }
    }
}