using Application.Features.Commands.ProgrammingLanguages.Request;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Handlers
{
    public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommandRequest, bool>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task<bool> Handle(DeleteProgrammingLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != null)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p=>p.Id==request.Id);
                if (programmingLanguage!=null)
                {
                    await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                    return true;
                }
                throw new BusinessException("Cannot find entity");
            }
            return false;

        }
    }
}
