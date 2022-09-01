using Application.Features.ProgrammingLanguages.Queries.Request;
using Application.Features.ProgrammingLanguages.Queries.Response;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Handlers
{
    public class GetProgrammingLanguageByIdQueryHandler : IRequestHandler<GetProgrammingLanguageByIdQueryRequest, GetProgrammingLanguageByIdQueryResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public GetProgrammingLanguageByIdQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<GetProgrammingLanguageByIdQueryResponse> Handle(GetProgrammingLanguageByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id!=null)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);
                if (programmingLanguage != null)
                {
                    return _mapper.Map<GetProgrammingLanguageByIdQueryResponse>(programmingLanguage);
                }
            }
            return null;
        }
    }
}
