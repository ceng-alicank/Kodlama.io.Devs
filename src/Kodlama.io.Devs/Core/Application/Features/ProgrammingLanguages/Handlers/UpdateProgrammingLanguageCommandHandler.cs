using Application.Features.Commands.ProgrammingLanguages.Response;
using Application.Features.ProgrammingLanguages.Request;
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
    public class UpdateProgrammingLanguageCommandHandler:IRequestHandler<UpdateProgrammingLanguageCommandRequest, UpdateProgrammingLanguageCommandResponse>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IMapper _mapper;

        public UpdateProgrammingLanguageCommandHandler(IMapper mapper, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _mapper = mapper;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<UpdateProgrammingLanguageCommandResponse> Handle(UpdateProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id!=null)
            {
                IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p => p.Name == request.Name);
                if (result.Items.Any()) throw new BusinessException("programming language name already exists");
                ProgrammingLanguage programmingLanguage =  _mapper.Map<ProgrammingLanguage>(request);
                await _programmingLanguageRepository.UpdateAsync(programmingLanguage);
                return _mapper.Map<UpdateProgrammingLanguageCommandResponse>(programmingLanguage);
            }
            return null;
        }
    }
}
