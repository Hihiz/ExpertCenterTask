using ExpertCenterTask.Application.Dto.Column;

namespace ExpertCenterTask.Application.Dto.PriceList
{
    public class CreatePriceListDto
    {
        public string Title { get; set; }
        public List</*ColumnCollectionDto*/ColumnDto> Columns { get; set; }
    }
}
