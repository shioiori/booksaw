using booksaw.application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksaw.application.Authors.AddAuthor
{
    public class AddAuthorCommand : IRequest<AuthorResponse>
    {
        public string Name { get; set; }
    }
}
