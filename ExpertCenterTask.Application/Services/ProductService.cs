using AutoMapper;
using ExpertCenterTask.Application.Dto.Product;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Services
{
    public class ProductService : IBaseService<ProductDto, CreateProductDto, UpdateProductDto>
    {
        private readonly IBaseRepository<Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IBaseRepository<Product> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<Product> products = await _repository.GetAll(cancellationToken);

                List<ProductDto> productDto = _mapper.Map<List<ProductDto>>(products);

                return productDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Product product = await _repository.GetById(id, cancellationToken);

                if (product == null)
                {
                    throw new Exception("Not found");
                }

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> Create(CreateProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new Exception("Not found");
                }

                Product product = _mapper.Map<Product>(dto);

                await _repository.Create(product, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ProductDto> Update(int id, UpdateProductDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null || id != dto.Id)
                {
                    throw new Exception("Not found");
                }

                Product product = _mapper.Map<Product>(dto);

                await _repository.Update(product, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ProductDto productDto = _mapper.Map<ProductDto>(product);

                return productDto;
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
                Product product = await _repository.GetById(id, cancellationToken);

                if (product == null)
                {
                    throw new Exception("Not found");
                }

                await _repository.Delete(product);
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
