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

namespace booksaw.application.Authors.AddAuthor
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, AuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        public AddAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<AuthorResponse> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = CustomMapper.Mapper.Map<Author>(request);
            _authorRepository.BeginTransaction();
            var newAuthor = await _authorRepository.AddAsync(authorEntity);
            var response = CustomMapper.Mapper.Map<AuthorResponse>(newAuthor);
            _authorRepository.Commit();
            return response;
        }
    }
}
