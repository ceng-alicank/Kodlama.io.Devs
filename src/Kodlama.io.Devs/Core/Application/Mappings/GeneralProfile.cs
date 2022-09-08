using Application.Dtos;
using Application.Features.Commands.ProgrammingLanguages.Request;
using Application.Features.Commands.ProgrammingLanguages.Response;
using Application.Features.ProgrammingLanguages.Queries.Response;
using Application.Features.ProgrammingLanguages.Request;
using Application.Features.Technologies.Create;
using Application.Features.Technologies.GetList;
using Application.Features.Technologies.Update;
using Application.Features.Users.Create;
using Application.Features.Users.Login;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
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


            CreateMap<CreateTechnologyCommandRequest, Technology>();
            CreateMap<Technology, CreateTechnologyCommandResponse >();
            CreateMap< Technology, GetListTechnologyDto > ().ForMember(c => c.ProgrammingLanguageName , opt=>opt.MapFrom(t=>t.ProgrammingLanguage.Name));
            CreateMap<IPaginate<Technology>, GetListTechnologyQueryResponse>().ReverseMap();
            CreateMap<UpdateTechnologyCommandRequest, Technology>();
            CreateMap<Technology  ,UpdateTechnologyCommandResponse > ();


            CreateMap<CreateUserCommandRequest, User>();
            CreateMap<AccessToken, CreateUserCommandResponse>();
            CreateMap<AccessToken, LoginUserCommandResponse>();
        }
    }
}
