using booksaw.application.Mapper;
using booksaw.domain.Entities;
using booksaw.domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IBookRepository _repository;
        public DeleteBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {

            if (await _repository.GetByIdAsync(request.Id) == null)
            {
                return false;
            }
            var bookEntity = CustomMapper.Mapper.Map<Book>(request);

            await _repository.UpdateAsync(bookEntity);
            _repository.Commit();
            return true;
        }
    }
}
