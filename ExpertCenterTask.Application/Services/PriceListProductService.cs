using AutoMapper;
using ExpertCenterTask.Application.Dto.PriceListProduct;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Services
{
    public class PriceListProductService : IBaseService<PriceListProductDto, CreatePriceListProductDto, UpdatePriceListProductDto>
    {
        private readonly IBaseRepository<PriceListProduct> _repository;
        private readonly IMapper _mapper;

        public PriceListProductService(IBaseRepository<PriceListProduct> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<PriceListProductDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<PriceListProduct> priceListProducts = await _repository.GetAll(cancellationToken);

                List<PriceListProductDto> priceListProductDto = _mapper.Map<List<PriceListProductDto>>(priceListProducts);

                return priceListProductDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListProductDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                PriceListProduct priceListProduct = await _repository.GetById(id, cancellationToken);

                if (priceListProduct == null)
                {
                    throw new Exception("Not found");
                }

                PriceListProductDto priceListProductDto = _mapper.Map<PriceListProductDto>(priceListProduct);

                return priceListProductDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<PriceListProductDto> Create(CreatePriceListProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new Exception("Not found");
                }

                PriceListProduct priceListProduct = _mapper.Map<PriceListProduct>(dto);

                await _repository.Create(priceListProduct, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListProductDto priceListDto = _mapper.Map<PriceListProductDto>(priceListProduct);

                return priceListDto;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public async Task<PriceListProductDto> Update(int id, UpdatePriceListProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null || id != dto.PriceListId)
                {
                    throw new Exception("Not found");
                }

                PriceListProduct priceListProduct = _mapper.Map<PriceListProduct>(dto);

                await _repository.Update(priceListProduct, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                PriceListProductDto priceListProductDto = _mapper.Map<PriceListProductDto>(priceListProduct);

                return priceListProductDto;
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
                PriceListProduct priceListProduct = await _repository.GetById(id, cancellationToken);

                if (priceListProduct == null)
                {
                    throw new Exception("Not found");
                }

                await _repository.Delete(priceListProduct);
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
