using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceList;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Services
{
    public class PriceListService : IPriceListService<PriceListDto, PriceListDetailDto, CreatePriceListDto, UpdatePriceListDto>
    {
        private readonly IBaseRepository<PriceList> _repository;
        private readonly IBaseRepository<PriceListProduct> _repositoryPriceListProd;
        private readonly IBaseRepository<PriceListColumn> _repositoryPriceListCol;
        private readonly IMapper _mapper;

        public PriceListService(IBaseRepository<PriceList> repository, IBaseRepository<PriceListProduct> repositoryPriceListProd, IBaseRepository<PriceListColumn> repositoryPriceListCol, IMapper mapper)
            => (_repository, _repositoryPriceListProd, _repositoryPriceListCol, _mapper) = (repository, repositoryPriceListProd, repositoryPriceListCol, mapper);

        public async Task<List<PriceListDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<PriceList> priceLists = await _repository.GetAll(cancellationToken);

                List<PriceListDto> priceListDto = _mapper.Map<List<PriceListDto>>(priceLists);

                return priceListDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListDetailDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                PriceList priceList = await _repository.GetById(id, cancellationToken);

                PriceListProduct priceListProduct = await _repositoryPriceListProd.GetById(id, cancellationToken);

                PriceListColumn priceListColumn = await _repositoryPriceListCol.GetById(id, cancellationToken);

                if (priceList == null)
                {
                    throw new Exception("Not found");
                }

                PriceListDetailDto priceListDetailDtoV2 = new()
                {
                    Id = priceList.Id,
                    Title = priceList.Title,
                    ProductTitle = priceListProduct.Product.Title,
                    ProductArcticle = priceListProduct.Product.Arcticle,
                    Columns = priceList.PriceListColumns.Select(p => new Dto.Column.ColumnDto
                    {
                        Id = p.ColumnId,
                        Title = p.Column.Title,
                        Type = p.Column.Type.ToString(),
                        Value = p.Column.Value
                    }).ToList()
                };


                return priceListDetailDtoV2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListDto> Create(CreatePriceListDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new Exception("Not found");
                }

                PriceList priceList = _mapper.Map<PriceList>(dto);

                await _repository.Create(priceList, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListDto priceListDto = _mapper.Map<PriceListDto>(priceList);

                return priceListDto;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListDto> Update(int id, UpdatePriceListDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null || id != dto.Id)
                {
                    throw new Exception("Not found");
                }

                PriceList priceList = _mapper.Map<PriceList>(dto);

                await _repository.Update(priceList, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListDto priceListDto = _mapper.Map<PriceListDto>(priceList);

                return priceListDto;
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
                PriceList priceList = await _repository.GetById(id, cancellationToken);

                if (priceList == null)
                {
                    throw new Exception("Not found");
                }

                await _repository.Delete(priceList);
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
