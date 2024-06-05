namespace ExpertCenterTask.Domain.Entities
{
    public class PriceListColumn
    {
        public int PriceListId { get; set; }
        public PriceList? PriceList { get; set; }

        public int ColumnId { get; set; }
        public Column? Column { get; set; }
    }
}
