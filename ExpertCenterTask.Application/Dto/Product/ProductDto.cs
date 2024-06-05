using ExpertCenterTask.Application.Dto.Column;

namespace ExpertCenterTask.Application.Dto.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Arcticle { get; set; }
        public List</*ColumnCollectionDto*/ColumnDto> Columns { get; set; }
    }
}
