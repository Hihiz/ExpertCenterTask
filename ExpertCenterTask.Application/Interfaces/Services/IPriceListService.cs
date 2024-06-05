namespace ExpertCenterTask.Application.Interfaces.Services
{
    public interface IPriceListService<T, TDetailDto, TCreateDto, TUpdateDto>
    {
        Task<List<T>> GetAll(CancellationToken cancellationToken = default);
        Task<TDetailDto> GetById(int id, CancellationToken cancellationToken = default);
        Task<T> Create(TCreateDto dto, CancellationToken cancellationToken = default);
        Task<T> Update(int id, TUpdateDto dto, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
    }
}
