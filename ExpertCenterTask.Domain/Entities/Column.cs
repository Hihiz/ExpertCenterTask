namespace ExpertCenterTask.Domain.Entities
{
    public class Column
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Domain.Enums.Type Type { get; set; }
        public string Value { get; set; }

        public ICollection<PriceListColumn> PriceListColumns { get; } = new List<PriceListColumn>();
    }
}
