using AutoMapper;
using ExpertCenterTask.Application.Dto.Column;
using ExpertCenterTask.Application.Interfaces.Repositories;
using ExpertCenterTask.Application.Interfaces.Services;
using ExpertCenterTask.Domain.Entities;

namespace ExpertCenterTask.Application.Services
{
    public class ColumnService : IBaseService<ColumnDto, CreateColumnDto, UpdateColumnDto>
    {
        private readonly IBaseRepository<Column> _repository;
        private readonly IMapper _mapper;

        public ColumnService(IBaseRepository<Column> repository, IMapper mapper) => (_repository, _mapper) = (repository, mapper);

        public async Task<List<ColumnDto>> GetAll(CancellationToken cancellationToken = default)
        {
            try
            {
                List<Column> columns = await _repository.GetAll(cancellationToken);

                List<ColumnDto> columnDto = _mapper.Map<List<ColumnDto>>(columns);

                return columnDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ColumnDto> GetById(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                Column column = await _repository.GetById(id, cancellationToken);

                if (column == null)
                {
                    throw new Exception("Not found");
                }

                ColumnDto columnDto = _mapper.Map<ColumnDto>(column);

                return columnDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ColumnDto> Create(CreateColumnDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null)
                {
                    throw new Exception("Not found");
                }

                Column column = _mapper.Map<Column>(dto);

                await _repository.Create(column, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ColumnDto columnDto = _mapper.Map<ColumnDto>(column);

                return columnDto;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<ColumnDto> Update(int id, UpdateColumnDto dto, CancellationToken cancellationToken = default)
        {
            try
            {
                if (dto == null || id != dto.Id)
                {
                    throw new Exception("Not found");
                }

                Column column = _mapper.Map<Column>(dto);

                await _repository.Update(column, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);

                ColumnDto columnDto = _mapper.Map<ColumnDto>(column);

                return columnDto;
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
                Column column = await _repository.GetById(id, cancellationToken);

                if (column == null)
                {
                    throw new Exception("Not found");
                }

                await _repository.Delete(column);
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
