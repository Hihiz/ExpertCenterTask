using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceListColumn;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Services
{
    public class PriceListColumnService : IBaseService<PriceListColumnDto, CreatePriceListColumnDto, UpdatePriceListColumnDto>
    {
        private readonly IBaseRepository<PriceListColumn> _repository;
        private readonly IMapper _mapper;

        public PriceListColumnService(IBaseRepository<PriceListColumn> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<PriceListColumnDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<PriceListColumn> priceListColumns = await _repository.GetAll(cancellationToken);

                List<PriceListColumnDto> priceListColumnDto = _mapper.Map<List<PriceListColumnDto>>(priceListColumns);

                return priceListColumnDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListColumnDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                PriceListColumn priceListColumn = await _repository.GetById(id, cancellationToken);

                if (priceListColumn == null)
                {
                    throw new Exception("Not found");
                }

                PriceListColumnDto priceListColumnDto = _mapper.Map<PriceListColumnDto>(priceListColumn);

                return priceListColumnDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListColumnDto> Create(CreatePriceListColumnDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new Exception("Not found");
                }

                PriceListColumn priceList = _mapper.Map<PriceListColumn>(dto);

                await _repository.Create(priceList, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListColumnDto priceListDto = _mapper.Map<PriceListColumnDto>(priceList);

                return priceListDto;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<PriceListColumnDto> Update(int id, UpdatePriceListColumnDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null || id != dto.PriceListId)
                {
                    throw new Exception("Not found");
                }

                PriceListColumn priceListColumn = _mapper.Map<PriceListColumn>(dto);

                await _repository.Update(priceListColumn, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListColumnDto priceListColumnDto = _mapper.Map<PriceListColumnDto>(priceListColumn);

                return priceListColumnDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task Delete(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                PriceListColumn priceListColumn = await _repository.GetById(id, cancellationToken);

                if (priceListColumn == null)
                {
                    throw new Exception("Not found");
                }

                await _repository.Delete(priceListColumn);
                await _repository.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
