namespace ExpertCenterTask.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Arcticle { get; set; }

        public ICollection<PriceListProduct> PriceListProducts { get; } = new List<PriceListProduct>();
    }
}
