﻿using AutoMapper;
using OzeSome.Data.Models.Contexts;

namespace OzeSomeAPI.Services
{
    /// <summary>
    /// Base service class for all services
    /// </summary>
    /// <typeparam name="ModelType">Type of Model</typeparam>
    /// <typeparam name="Dto"> Type of Dto</typeparam>
    /// /// <typeparam name="NewDto"> Type of Dto to create model</typeparam>
    public abstract class BaseService<ModelType, Dto, NewDto>
    {
        protected readonly DatabaseContext _context;
        protected readonly IMapper _mapper;

        public BaseService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public abstract Task<Dto> GetByIdAsync(Guid id);

        public abstract Task<IEnumerable<Dto>> GetAllAsync();

        public abstract Task<Dto> CreateAsync(NewDto dto);

        public abstract Task<ModelType> UpdateAsync(Dto dto);

        public abstract Task<bool> DeleteAsync(Guid id);
    }

}
