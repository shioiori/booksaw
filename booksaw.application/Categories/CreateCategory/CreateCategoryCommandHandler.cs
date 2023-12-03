using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Entities;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Categories.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly ICategoryRepository _repository;
        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryEntity = CustomMapper.Mapper.Map<Category>(request);
            _repository.BeginTransaction();
            var newCategory = await _repository.AddAsync(categoryEntity);
            var response = CustomMapper.Mapper.Map<CategoryResponse>(newCategory);
            _repository.Commit();
            return response;
        }
    }
}
