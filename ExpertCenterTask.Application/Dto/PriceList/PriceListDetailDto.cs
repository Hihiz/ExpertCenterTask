using ExpertCenterTask.Application.Dto.Column;

namespace ExpertCenterTask.Application.Dto.PriceList
{
    public class PriceListDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductTitle { get; set; }
        public string ProductArcticle { get; set; }
        public List</*ColumnCollectionDto*/ColumnDto> Columns { get; set; }
    }
}
