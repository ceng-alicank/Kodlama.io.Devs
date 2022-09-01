using Application.Dtos;
using Application.Features.ProgrammingLanguages.Queries.Response;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Queries.Request
{
    public class GetProgrammingLanguageByIdQueryRequest:IRequest<GetProgrammingLanguageByIdQueryResponse>
    {
        public int Id { get; set; }
    }
}
