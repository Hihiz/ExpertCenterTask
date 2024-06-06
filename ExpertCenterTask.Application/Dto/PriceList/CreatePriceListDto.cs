using ExpertCenterTask.Application.Dto.Column;

namespace ExpertCenterTask.Application.Dto.PriceList
{
    public class CreatePriceListDto
    {
        public string Title { get; set; }
        public List<ColumnDto> Columns { get; set; }
    }
}
