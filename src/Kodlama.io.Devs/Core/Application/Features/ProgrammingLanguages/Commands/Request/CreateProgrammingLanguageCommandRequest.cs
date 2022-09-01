using Application.Features.Commands.ProgrammingLanguages.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.ProgrammingLanguages.Request
{
    public class CreateProgrammingLanguageCommandRequest:IRequest<CreateProgrammingLanguageCommandResponse>
    {
        public string? Name { get; set; }
    }
}
