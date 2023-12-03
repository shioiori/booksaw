using booksaw.application.Mapper;
using booksaw.application.Response;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Categories.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryResponse>>
    {
        private readonly ICategoryRepository _repository;
        public GetAllCategoryQueryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CategoryResponse>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            return CustomMapper.Mapper.Map<List<CategoryResponse>>(categories);
        }
    }
}
