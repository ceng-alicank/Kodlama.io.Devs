using Application.Features.ProgrammingLanguages.Queries.Request;
using Application.Features.ProgrammingLanguages.Queries.Response;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Handlers
{
    public class GetProgrammingLanguageListQueryHandler : IRequestHandler<GetProgrammingLanguageListQueryRequest, GetProgrammingLanguageListQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetProgrammingLanguageListQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }
        public async Task<GetProgrammingLanguageListQueryResponse> Handle(GetProgrammingLanguageListQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProgrammingLanguage> brands = await _programmingLanguageRepository.GetListAsync
                (index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            return _mapper.Map<GetProgrammingLanguageListQueryResponse>(brands);
        }
    }
}
