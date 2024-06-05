namespace ExpertCenterTask.Domain.Entities
{
    public class PriceListProduct
    {
        public int PriceListId { get; set; }
        public PriceList? PriceList { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}