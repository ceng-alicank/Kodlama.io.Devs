using Application.Features.Commands.ProgrammingLanguages.Request;
using Application.Features.Commands.ProgrammingLanguages.Response;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
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
    public class CreateProgrammingLanguageCommandHandler : IRequestHandler<CreateProgrammingLanguageCommandRequest, CreateProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public CreateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _mapper = mapper;
        }

        public async Task<CreateProgrammingLanguageCommandResponse> Handle(CreateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {

            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == request.Name);
            if (result.Items.Any()) throw new BusinessException("programming language name already exists");
            ProgrammingLanguage programmingLanguage = _mapper.Map<ProgrammingLanguage>(request);
            await _programmingLanguageRepository.AddAsync(programmingLanguage);
            CreateProgrammingLanguageCommandResponse createdProgrammingLanguage = _mapper.Map<CreateProgrammingLanguageCommandResponse>(programmingLanguage);
            return createdProgrammingLanguage;
        }
    }
}
