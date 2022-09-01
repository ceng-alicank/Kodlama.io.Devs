using Application.Features.Commands.ProgrammingLanguages.Request;
using Application.Features.Commands.ProgrammingLanguages.Response;
using Application.Features.ProgrammingLanguages.Queries.Response;
using Application.Features.ProgrammingLanguages.Request;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProgrammingLanguageCommandRequest, ProgrammingLanguage>();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommandResponse>();
            CreateMap<UpdateProgrammingLanguageCommandRequest, ProgrammingLanguage>();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommandResponse>();
            CreateMap<DeleteProgrammingLanguageCommandRequest, ProgrammingLanguage>();
            CreateMap<IPaginate<ProgrammingLanguage>, GetProgrammingLanguageListQueryResponse>().ReverseMap();
            CreateMap<ProgrammingLanguage, GetProgrammingLanguageByIdQueryResponse>().ReverseMap();
        }
    }
}
