using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Create
{
    public class CreateTechnologyCommandRequest:IRequest<CreateTechnologyCommandResponse>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
