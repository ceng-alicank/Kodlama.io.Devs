using Application.Features.ProgrammingLanguages.Queries.Response;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.Request
{
    public class GetProgrammingLanguageListQueryRequest : IRequest<IPaginate<ProgrammingLanguage>>
    {
        public PageRequest PageRequest { get; set; }
        
    }
}
