namespace ExpertCenterTask.Domain.Entities
{
    public class PriceList
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<PriceListProduct> PriceListProducts { get; } = new List<PriceListProduct>();
        public ICollection<PriceListColumn> PriceListColumns { get; } = new List<PriceListColumn>();
    }
}
