using ExpertCenterTask.Application.Dto.Column;

namespace ExpertCenterTask.Application.Dto.PriceList
{
    public class UpdatePriceListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List</*ColumnCollectionDto*/ColumnDto> Columns { get; set; }
    }
}
