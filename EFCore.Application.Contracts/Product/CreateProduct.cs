namespace EFCore.Application.Contracts.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
